using System;
using System.Collections.Generic;

namespace NashSoft.BehaviourRecorder
{
    public class TestingEvent
    {
        public EventType EventType { get; set; }
        public TestSketch TestSketch { get; set; }
        public string MethodName { get; set; }
        public IList<ParameterTypeValuePair> ParameterTypeValuePairs { get; set; }
        public IList<ParameterTypeValuePair> ParameterTypeValuePairsToBeLogged { get; set; }
        public Attribute EventCausingAttribute { get; set; } 

    }
}