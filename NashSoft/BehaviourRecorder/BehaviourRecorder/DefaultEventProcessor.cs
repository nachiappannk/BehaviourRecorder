namespace NashSoft.BehaviourRecorder
{
    [BehaviourRecorderPlugin(true,0)]
    public class DefaultEventProcessor : IEventProcessor
    {
        public ProcessedEvent ProcessEvent(TestingEvent testingEvent)
        {
            var processedEvent = new MultipleLinesContainingProcessedEvent();
            var methodName = testingEvent.MethodName;
            var methodNameAsSentence = PascalCaseToSentenceConverter.Convert(methodName);
            var saidVariableConvertedSentence = SaidVariableToBracketedVariableConverter.Convert(methodNameAsSentence);
            processedEvent.Lines.Add(saidVariableConvertedSentence);
            return processedEvent;
        }
    }
}