using System;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RecordWhenAttribute : RecordAttribute
    {
        public RecordWhenAttribute() : base(EventType.WhenStarted, EventType.WhenEnded) { }
        public RecordWhenAttribute(string name) : base(name, EventType.WhenStarted, EventType.WhenEnded) { }
        
    }
}