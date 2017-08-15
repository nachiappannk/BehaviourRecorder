namespace NashSoft.BehaviourRecorder
{
    public interface IProcessedEventSink
    {
        void Sink(ProcessedEvent processedEvent, string uniqueTestCaseIdentifier, int eventCount);
    }
}