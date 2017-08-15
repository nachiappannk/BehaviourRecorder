using System;
using NUnit.Framework;

namespace NashSoft.BehaviourRecorder.NUnit
{
    [BehaviourRecorderPlugin(true, 0)]
    public class NUnitProcessedEventSink : IProcessedEventSink
    {
        private readonly string _indendation1 = "  ";
        private readonly string _indendation2 = "    ";
        public void Sink(TestingEvent testingEvent, string uniqueTestCaseIdentifier, int eventCount)
        {
            if (IsFirstEvent(eventCount))
            {
                LogFeature(testingEvent);
                LogScenario(testingEvent);
            }
            if (testingEvent.EventSubType == EventSubType.Started)
            {
                if (testingEvent.EventType != EventType.Scenario)
                {
                    var methodName = testingEvent.MethodName;
                    var methodNameAsSentence = PascalCaseToSentenceConverter.Convert(methodName);
                    var saidConvertedSentence = SaidVariableToBracketedVariableConverter.Convert(methodNameAsSentence);
                    var eventString = testingEvent.EventType.ToString();
                    Log(_indendation2 +"("+eventString+") "+ saidConvertedSentence);
                }
            }
        }

        private void LogScenario(TestingEvent testingEvent)
        {

            var scenarioName = testingEvent.TestSketch.TestMethod.Name;
            var scenarioNameAsSentence = PascalCaseToSentenceConverter.Convert(scenarioName);
            var saidConvertedSentence = SaidVariableToBracketedVariableConverter.Convert(scenarioNameAsSentence);
            Log(_indendation1 + "Scenario :" + saidConvertedSentence);
        }

        private void LogFeature(TestingEvent testingEvent)
        {
            var name = testingEvent.TestSketch.TestClassType.Name;
            Log("Feature :"+PascalCaseToSentenceConverter.Convert(name));
        }

        private static bool IsFirstEvent(int eventCount)
        {
            return eventCount == 1;
        }

        private void Log(string line)
        {
            TestContext.WriteLine(line);
        }
    }
}