namespace NashSoft.BehaviourRecorder
{
    public interface IEventProcessor
    {
        ProcessedEvent ProcessEvent(TestingEvent testingEvent);
    }
}