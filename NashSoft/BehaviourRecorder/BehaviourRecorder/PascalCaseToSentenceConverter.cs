using System.Text.RegularExpressions;

namespace NashSoft.BehaviourRecorder
{
    public static class PascalCaseToSentenceConverter
    {
        public static string Convert(string input)
        {
            return Regex.Replace(input, "[a-z0-9][A-Z]", n => n.Value[0] + " " + char.ToLower(n.Value[1]));            
        }
    }
}