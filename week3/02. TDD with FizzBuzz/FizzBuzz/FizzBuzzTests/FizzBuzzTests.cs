using FizzBuzzApp;

namespace FizzBuzzTests
{
    public class FizzBuzzDoes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FizzBuzz_ReturnsNothing_GivenZero()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(0), Is.EqualTo(""));
        }

        [Test]
        public void FizzBuzz_ReturnsOneTwo_GivenTwo()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(2), Is.EqualTo("1 2"));
        }

        [Test]
        [Ignore("No longer part of TDD process.")]
        public void FizzBuzz_ReturnsOneTwoThree_GivenThree()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(3), Is.EqualTo("1 2 3"));
        }

        [Test]
        public void FizzBuzz_ReturnsOneTwoFizz_GivenThree()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(3), Is.EqualTo("1 2 Fizz"));
        }

        [Test]
        public void FizzBuzz_ReturnsOneTwoFizzFourBuzz_GivenFive()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(5), Is.EqualTo("1 2 Fizz 4 Buzz"));
        }

        [Test]
        public void FizzBuzz_ReturnsExpected_GivenFifteen()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(15), Is.EqualTo("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz"));
        }
    }
}