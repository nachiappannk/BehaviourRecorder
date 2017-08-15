using System;
using System.Collections.Generic;

namespace NashSoft.BehaviourRecorder
{
    //TODO Feature handling has to be done
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public sealed class RecordFeatureAttribute : Attribute
    {
        public RecordFeatureAttribute(string name, IList<string> description)
        {
            Name = name;
            Description = description;
            IsNameSet = true;
        }

        public RecordFeatureAttribute(string name)
        {
            Name = name;
            IsNameSet = true;
            Description = new List<string>();
        }

        public RecordFeatureAttribute()
        {
            IsNameSet = false;
            Name = String.Empty;
            Description = new List<string>();
        }

        public bool IsNameSet { get; set; }
        public string Name { get; private set; }
        public IList<string> Description { get; private set; }
    }
}