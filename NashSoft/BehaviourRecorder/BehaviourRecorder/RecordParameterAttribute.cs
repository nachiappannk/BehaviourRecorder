using System;

namespace NashSoft.BehaviourRecorder
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class RecordParameterAttribute : Attribute
    {
    }
}