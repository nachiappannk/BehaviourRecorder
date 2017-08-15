using System.Text;

namespace NashSoft.BehaviourRecorder
{
    public static class SaidVariableToBracketedVariableConverter
    {
        public static string Convert(string input)
        {
            var splitWords = input.Split(' ');
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < splitWords.Length; i++)
            {
                if (splitWords[i] == "said")
                {
                    if (i + 1 < splitWords.Length)
                    {
                        splitWords[i + 1] = "<<" + splitWords[i + 1] + ">>";
                    }
                }
                else
                {
                    s.Append(splitWords[i]).Append(" ");
                }
            }
            return s.ToString();
        }
    }
}