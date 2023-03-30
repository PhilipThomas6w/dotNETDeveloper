using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ExceptionTests
{
    public class Tests
    {
        // Arranged
        [TestCase(-20)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(140)]

        public void GivenInvalidData_GetGrade_ThrowsArgumentOutOfBoundsException(int grade)
        {
            Assert.That(() => Program.GetGrade(grade), Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => Program.GetGrade(grade), Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Message.Contain("Argument 'grade' needs to be between 0 and 100"));
        }


    }
}