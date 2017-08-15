using System;

namespace NashSoft.BehaviourRecorder
{
    public class BehaviourRecorderPluginAttribute : Attribute
    {
        public BehaviourRecorderPluginAttribute(bool enabled, int weight)
        {
            Enabled = enabled;
            Weight = weight;
        }
        public bool Enabled { get; set; }
        public int Weight { get; set; }
    }
}