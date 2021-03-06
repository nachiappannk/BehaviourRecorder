﻿using System;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RecordGivenAttribute : RecordAttribute
    {
        public RecordGivenAttribute() : base(EventType.Given) { }
        public RecordGivenAttribute(string name) : base(name, EventType.Given) { }
    }
}