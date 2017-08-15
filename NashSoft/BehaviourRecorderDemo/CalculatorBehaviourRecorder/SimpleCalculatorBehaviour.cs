using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NashSoft.BehaviourRecorder.PostSharp;
using NUnit.Framework;

namespace CalculatorBehaviourRecorder
{
    [TestFixture]
    public class SimpleCalculatorBehaviour
    {
        [SetUp]
        public void SetUp()
        {
            CreateCalculator();
            ClearCalculatorOfPreviousCalculation();
        }

        [RecordGiven]
        private void ClearCalculatorOfPreviousCalculation()
        {
        }

        [RecordGiven]
        private void CreateCalculator()
        {
        }

        [TestCase(4,5,9)]
        [RecordScenario]
        public void AdditionOfTwoNumbersScenario(int input1, int input2, int result)
        {
            KeyInSaidInput(input1);
            KeyInPlusSign();
            KeyInSaidInput(input2);
            PressEqualTo();
            ResultShouldBeSaidValue(result);
        }

        [RecordThen]
        private void ResultShouldBeSaidValue(int result)
        {
        }

        [RecordWhen]
        private void PressEqualTo()
        {
        }

        [RecordWhen]
        private void KeyInPlusSign()
        {
        }

        [RecordWhen]
        private void KeyInSaidInput(int input)
        {
        }
    }
}
