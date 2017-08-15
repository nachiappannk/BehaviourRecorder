using System.Collections.Generic;

namespace NashSoft.BehaviourRecorder
{
    public class MultipleLinesContainingProcessedEvent : ProcessedEvent
    {
        public MultipleLinesContainingProcessedEvent()
        {
            Lines = new List<string>();
        }
        public List<string> Lines { get; set; } 
    }
}