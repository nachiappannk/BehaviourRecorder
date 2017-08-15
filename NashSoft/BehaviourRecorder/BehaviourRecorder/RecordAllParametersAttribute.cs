using System;

namespace NashSoft.BehaviourRecorder
{
    //TODO Parameter handling has to be done
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RecordAllParametersAttribute : Attribute
    {
    }
}