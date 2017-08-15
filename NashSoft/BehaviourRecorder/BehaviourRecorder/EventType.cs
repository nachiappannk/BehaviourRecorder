namespace NashSoft.BehaviourRecorder
{
    public enum EventType
    {
        Given,
        When,
        Then,
        But,
        Scenario,
    }

    public enum EventSubType
    {
        Started,
        Ended,
    }


    public static class EventTypeExtension
    {
        public static string GetString(this EventType eventType)
        {
            switch (eventType)
            {
                case EventType.Given:
                    return "Given";
                case EventType.When:
                    return "When";
                case EventType.Then:
                    return "Then";
                case EventType.But:
                    return "But";
                case EventType.Scenario:
                default:
                    return "Scenario";


            }
        }
    }
}