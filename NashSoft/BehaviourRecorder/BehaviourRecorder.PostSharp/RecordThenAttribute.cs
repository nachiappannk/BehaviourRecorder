using System;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RecordThenAttribute : RecordAttribute
    {
        public RecordThenAttribute() : base(EventType.Then) { }
        public RecordThenAttribute(string name) : base(name, EventType.Then) { }
        
    }
}