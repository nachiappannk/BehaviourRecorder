using System;
using PostSharp.Aspects;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    public class RecordAttribute : OnMethodBoundaryAspect
    {
        private readonly EventType _endedEvent;
        private readonly EventType _startedEvent;

        public RecordAttribute(string name, EventType startedEvent, EventType endedEvent)
        {
            _endedEvent = endedEvent;
            _startedEvent = startedEvent;
            IsNameSet = true;
            Name = name;
        }

        public RecordAttribute(EventType startedEvent, EventType endedEvent)
        {
            _startedEvent = startedEvent;
            _endedEvent = endedEvent;
            IsNameSet = false;
            Name = String.Empty;
        }

        //TODO these should be made in an interface
        public bool IsNameSet { get; private set; }
        public string Name { get; private set; }

        public sealed override void OnEntry(MethodExecutionArgs args)
        {
            RunFlow(_startedEvent, args.Method.Name);
        }

        private void RunFlow(EventType typeOfEvent, string methodName)
        {
            var testingEvent = CreateEvent(typeOfEvent, methodName);
            var processedEvent = ProcessEvent(testingEvent);
            LogProcessedEvent(processedEvent, testingEvent.TestSketch);
        }

        public sealed override void OnExit(MethodExecutionArgs args)
        {
            RunFlow(_endedEvent, args.Method.Name);
        }

        private TestingEvent CreateEvent(EventType typeOfEvent, string methodName)
        {
            var testSketchProvider = BehaviourRecorderPluginFactory<ITestSketchProvider>.CreatePlugin();
            TestingEvent testingEvent = new TestingEvent();
            testingEvent.TestSketch = testSketchProvider.GetTestSketch();
            testingEvent.EventCausingAttribute = this;
            testingEvent.EventType = typeOfEvent;
            testingEvent.MethodName = methodName;
            //TODO testingEvent.ParameterTypeValuePairs;
            //TODO testingEvent.ParameterTypeValuePairsToBeLogged;
            return testingEvent;
        }

        private static ProcessedEvent ProcessEvent(TestingEvent testingEvent)
        {
            var eventProcessor = BehaviourRecorderPluginFactory<IEventProcessor>.CreatePlugin();
            var processedEvent = eventProcessor.ProcessEvent(testingEvent);
            return processedEvent;
        }

        private static void LogProcessedEvent(ProcessedEvent processedEvent, TestSketch testSketch)
        {
            var eventLogger = BehaviourRecorderPluginFactory<IProcessedEventSink>.CreatePlugin();
            //TODO the 0 in the argument has to be corrected
            eventLogger.Sink(processedEvent, testSketch.UniqueTestCaseIdentifier, 0);
        }
    }
}