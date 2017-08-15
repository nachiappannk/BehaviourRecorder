using System;
using System.Threading;
using PostSharp.Aspects;

namespace NashSoft.BehaviourRecorder.PostSharp
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    [Serializable]
    public sealed class RecordScenarioAttribute : RecordAttribute
    {
        public RecordScenarioAttribute(string name) : base(EventType.ScenarioStarted, EventType.ScenarioEnded)
        {
        }

        public RecordScenarioAttribute():base(EventType.ScenarioStarted, EventType.ScenarioEnded)
        {
        }
    }
}