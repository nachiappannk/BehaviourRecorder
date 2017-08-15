//TODO add copy right

using System;
using System.Collections.Generic;
using System.Reflection;

namespace NashSoft.BehaviourRecorder
{
    public class TestSketch
    {
        public string UniqueTestCaseIdentifier { get; set; }
        public Type TestClassType { get; set; }
        public MethodBase TestMethod { get; set; }
        public IList<object> TestParameters { get; set; }
    }
}