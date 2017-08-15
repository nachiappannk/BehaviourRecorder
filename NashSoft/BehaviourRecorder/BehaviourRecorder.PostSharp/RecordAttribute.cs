using System;
using System.Collections.Generic;
using PostSharp.Aspects;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    public class RecordAttribute : OnMethodBoundaryAspect
    {
        private readonly EventType _eventType;

        public RecordAttribute(string name, EventType eventType)
        {
            _eventType = eventType;
            IsNameSet = true;
            Name = name;
        }

        public RecordAttribute(EventType eventType)
        {
            _eventType = eventType;
            IsNameSet = false;
            Name = String.Empty;
        }

        //TODO these should be made in an interface
        public bool IsNameSet { get; private set; }
        public string Name { get; private set; }

        public sealed override void OnEntry(MethodExecutionArgs args)
        {
            GenerateAndLog(EventSubType.Started, args.Method.Name);
        }

        private void GenerateAndLog(EventSubType subType, string methodName)
        {
            var testingEvent = CreateEvent(subType, methodName);
            LogEvent(testingEvent, testingEvent.TestSketch);
        }

        public sealed override void OnExit(MethodExecutionArgs args)
        {
            GenerateAndLog(EventSubType.Ended, args.Method.Name);
        }

        private TestingEvent CreateEvent(EventSubType subType, string methodName)
        {
            var testSketchProvider = BehaviourRecorderPluginFactory<ITestSketchProvider>.CreatePlugin();
            TestingEvent testingEvent = new TestingEvent();
            testingEvent.TestSketch = testSketchProvider.GetTestSketch();
            testingEvent.EventCausingAttribute = this;
            testingEvent.EventType = _eventType;
            testingEvent.EventSubType = subType;
            testingEvent.MethodName = methodName;
            //TODO testingEvent.ParameterTypeValuePairs;
            //TODO testingEvent.ParameterTypeValuePairsToBeLogged;
            return testingEvent;
        }

        private static void LogEvent(TestingEvent testingEvent, TestSketch testSketch)
        {
            var eventLogger = BehaviourRecorderPluginFactory<IProcessedEventSink>.CreatePlugin();
            int eventCount = EventSerialNumberGenerator.GenerateSerialNumber(testSketch.UniqueTestCaseIdentifier);
            eventLogger.Sink(testingEvent, testSketch.UniqueTestCaseIdentifier, eventCount);
        }
    }

    public static class EventSerialNumberGenerator
    {
        public static Dictionary<string, int> eventCountingDictionary = new Dictionary<string, int>();
        public static int GenerateSerialNumber(string uniqueTestCaseIdentifier)
        {
            if(!eventCountingDictionary.ContainsKey(uniqueTestCaseIdentifier))
                eventCountingDictionary.Add(uniqueTestCaseIdentifier, 0);
            var count = eventCountingDictionary[uniqueTestCaseIdentifier];
            count++;
            eventCountingDictionary[uniqueTestCaseIdentifier] = count;
            return count;
        }
    }
}