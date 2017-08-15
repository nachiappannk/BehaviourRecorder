namespace NashSoft.BehaviourRecorder
{
    public interface IProcessedEventSink
    {
        void Sink(TestingEvent testingEvent, string uniqueTestCaseIdentifier, int eventCount);
    }
}