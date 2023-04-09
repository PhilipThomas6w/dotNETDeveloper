using NUnit.Framework;
using DataTypes_Lib;
using System;

namespace DataTypes_Test
{
    public class CalculatorTests
    {
        [Test]
        public void WhenGivenTwoIntegers_Add_ReturnsCorrectAnswer()
        {
            Assert.That(IntegerCalc.Add(3, 7), Is.EqualTo(10));
        }

        [Test] 
        public void WhenGivenTwoVeryLargeIntegers_Add_ThrowsAnException()
        {
            Assert.That(() => IntegerCalc.Add(int.MaxValue, 3), Throws.TypeOf<OverflowException>()); 
        }
        /* The purpose of passing int.MaxValue as the first argument and 3 as the second argument is to create
         * a scenario where the sum of the two integers exceeds the maximum value of an integer. The maximum 
         * value of an integer is 2,147,483,647; adding 3 to it will result in an integer overflow.
         */

        [Test]
        public void WhenGivenTwoVeryNegativeIntegers_Add_ThrowsAnException()
        {
            Assert.That(() => IntegerCalc.Add(int.MinValue, -3), Throws.TypeOf<OverflowException>());
        }
        /* This is similar to the test above. The minimum value of an interger is -2,147,483,648; taking 3
           away from it should likewise result in an integer overflow. We should be able to use the same method.  
         */


        [Test]
        public void WhenGivenTwoIntegers_Subtract_ReturnsCorrectAnswer()
        {
            Assert.That(IntegerCalc.Subtract(3, 7), Is.EqualTo(-4));
        }

        [Test]
        public void WhenGivingLargeOperands_Subtract_ThrowsAnException()
        {
            Assert.That(() => IntegerCalc.Subtract(int.MaxValue, -3), Throws.TypeOf<OverflowException>());
        }

        [Test]
        public void WhenGivingMoreLargeOperands_Subtract_ThrowsAnException()
        {
            Assert.That(() => IntegerCalc.Subtract(int.MinValue, 3), Throws.TypeOf<OverflowException>());
        }

        [TestCase(9, 3, 3)]
        [TestCase(9, 2, 4)]
        [TestCase(9, -2, -4)]
        public void WhenGivenTwoInts_Divide_ReturnsCorrectAnswer(int num1, int num2, int expAnswer)
        {
            Assert.That(IntegerCalc.Divide(num1, num2), Is.EqualTo(expAnswer));
        }

        [Test]
        public void WhenGivenTwoInts_WhereTheSecondIntIsZero_Divide_ThrowsAnException()
        {
            Assert.That(() => IntegerCalc.Divide(8, 0), Throws.InstanceOf<ArgumentException>().With.Message.Contains("Can't divide by zero"));
        }

        [TestCase(9, 3, 0)]
        [TestCase(9, 2, 1)]
        [TestCase(9, -2, 1)]
        public void WhenGivenTwoInts_Modulus_ReturnsCorrectAnswer(int num1, int num2, int expAnswer)
        {
            Assert.That(IntegerCalc.Modulus(num1, num2), Is.EqualTo(expAnswer));
        }

        [Test]
        public void WhenGivenTwoInts_WhereTheSecondIntIsZero_Modulus_ThrowsAnException()
        {
            Assert.That(() => IntegerCalc.Modulus(8, 0), Throws.InstanceOf<ArgumentException>().With.Message.Contains("Can't modulo by zero"));
        }
    }
}
