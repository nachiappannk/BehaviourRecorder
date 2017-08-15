using System;
using NUnit.Framework;

namespace NashSoft.BehaviourRecorder.NUnit
{
    [BehaviourRecorderPlugin(true, 0)]
    public class NUnitProcessedEventSink : IProcessedEventSink
    {
        public void Sink(ProcessedEvent processedEvent, string uniqueTestCaseIdentifier, int eventCount)
        {
            if (!(processedEvent is MultipleLinesContainingProcessedEvent)) throw new SystemException();
            Log((MultipleLinesContainingProcessedEvent)processedEvent);
        }

        private void Log(MultipleLinesContainingProcessedEvent processedEvent)
        {
            foreach (var line in processedEvent.Lines)
            {
                TestContext.WriteLine(line);
            }
        }
    }
}