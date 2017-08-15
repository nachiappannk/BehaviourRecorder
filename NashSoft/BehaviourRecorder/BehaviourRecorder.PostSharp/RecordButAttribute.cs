using System;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RecordButAttribute : RecordAttribute
    {
        public RecordButAttribute() : base(EventType.But) { }
        public RecordButAttribute(string name) : base(name, EventType.But) { }
    }
}