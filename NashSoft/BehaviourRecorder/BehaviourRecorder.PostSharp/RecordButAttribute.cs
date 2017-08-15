using System;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RecordButAttribute : RecordAttribute
    {
        public RecordButAttribute() : base(EventType.ButStarted, EventType.ButEnded) { }
        public RecordButAttribute(string name) : base(name, EventType.ButStarted, EventType.ButEnded) { }
    }
}