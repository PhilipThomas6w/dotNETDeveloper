using ExceptionsApp;

namespace ExceptionsAppTests
{
    public class Tests
    {
        
        // Arrange
        [TestCase(-20)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(140)]
        public void GivenInvalidData_GetGrade_ThrowsArgumentOutOfRangeException(int percentage)
        {
            Assert.That(() => Program.GetGrade(percentage), Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Message.Contain("Percentage must be between 0 and 100."));
        }
    }
}