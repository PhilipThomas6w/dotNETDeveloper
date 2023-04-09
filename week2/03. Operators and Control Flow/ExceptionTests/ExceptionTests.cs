using OperatorsAndControlFlow;

namespace ExceptionTests
{
    [TestFixture]
    public class Tests
    {
        // Arrange
        [TestCase(-100)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(200)]
        public void GivenInvalidData_GetGrade_ThrowsArgumentOutOfBoundsException(int percentage)
        {
            // Assert 
            Assert.That(() => Program.GetGrade(percentage), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}