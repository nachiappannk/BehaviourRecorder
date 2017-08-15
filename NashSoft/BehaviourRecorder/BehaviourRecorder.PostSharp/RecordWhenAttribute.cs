using System;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RecordWhenAttribute : RecordAttribute
    {
        public RecordWhenAttribute() : base(EventType.When) { }
        public RecordWhenAttribute(string name) : base(name, EventType.When) { }
        
    }
}