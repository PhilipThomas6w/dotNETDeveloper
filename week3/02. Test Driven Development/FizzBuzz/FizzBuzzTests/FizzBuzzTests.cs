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
        public void GivenZero_FizzBuzz_ReturnsZero()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(0), Is.EqualTo(""));
        }

        [Test]
        public void GivenTwo_FizzBuzz_ReturnsOneTwo()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(2), Is.EqualTo("1 2"));
        }

        [Test]
        [Ignore("No longer part of TDD process.")]
        public void GivenThree_FizzBuzzReturnsOneTwoThree()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(3), Is.EqualTo("1 2 3"));
        }

        [Test]
        public void GivenThree_FizzBuzz_ReturnsOneTwoFizz()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(3), Is.EqualTo("1 2 Fizz"));
        }

        [Test]
        public void GivenFive_FizzBuzz_ReturnsOneTwoFizzFourBuzz()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(5), Is.EqualTo("1 2 Fizz 4 Buzz"));
        }

        [Test]
        public void GivenFifteen_FizzBuzz_ReturnsExpected()
        {
            // Assert            
            Assert.That(Program.FizzBuzz(15), Is.EqualTo("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz"));
        }
    }
}