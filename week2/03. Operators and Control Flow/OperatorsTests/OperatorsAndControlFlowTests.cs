using LoopExamples;
using OperatorsAndControlFlow;

namespace OperatorsAndControlFlowTests
{
    public class Tests
    {
        #region LOOP TESTS

        [TestCase(new int[] { 10, 6, 22, -17, 3 }, 22)]  // [TestCase] attribute won't take a list of integers as a parameter, but it will take an integer array.
        [TestCase(new int[] { 5, 19, 43, 117, -7 }, 117)]
        [TestCase(new int[] { -3, -54, -67, -5, -18 }, -3)]
        public void GivenIntArray_HighestForLoop_ReturnsHighestNumInArray(int[] numArray, int expectedResult) 
        {
            // Arrange
            List<int> nums = numArray.ToList();  // This converts the integer array that has been passed into this method body into a list that can be passed to my HighestForLoop method.

            // Act
            int highestNum = Loops.HighestForLoop(nums); // This passes the nums list to the HighestForLoop method and stores the return value in a variable called highestNum.

            // Assert
            Assert.That(highestNum, Is.EqualTo(expectedResult));  // This compares the value of highestNum to the value of expectedResult (second parameter in my TestCase).
        }

        [TestCase(new int[] { 10, 6, 22, -17, 3 }, 22)]
        [TestCase(new int[] { 5, 19, 43, 117, -7 }, 117)]
        [TestCase(new int[] { -3, -54, -67, -5, -18 }, -3)]
        public void GivenIntArray_HighestForEachLoop_ReturnsHighestNumInArray(int[] numArray, int expectedResult)
        {
            // Arrange
            List<int> nums = numArray.ToList();

            // Act
            int highestNum = Loops.HighestForEachLoop(nums);

            // Assert
            Assert.That(highestNum, Is.EqualTo(expectedResult));
        }

        [TestCase(new int[] { 10, 6, 22, -17, 3 }, 22)]
        [TestCase(new int[] { 5, 19, 43, 117, -7 }, 117)]
        [TestCase(new int[] { -3, -54, -67, -5, -18 }, -3)]
        public void GivenIntArray_HighestWhileLoop_ReturnsHighestNumInArray(int[] numArray, int expectedResult)
        {
            // Arrange
            List<int> nums = numArray.ToList();

            // Act
            int highestNum = Loops.HighestWhileLoop(nums);

            // Assert
            Assert.That(highestNum, Is.EqualTo(expectedResult));
        }

        [TestCase(new int[] { 10, 6, 22, -17, 3 }, 22)]
        [TestCase(new int[] { 5, 19, 43, 117, -7 }, 117)]
        [TestCase(new int[] { -3, -54, -67, -5, -18 }, -3)]
        public void GivenIntArray_HighestDoWhileLoop_ReturnsHighestNumInArray(int[] numArray, int expectedResult)
        {
            // Arrange
            List<int> nums = numArray.ToList();

            // Act
            int highestNum = Loops.HighestDoWhileLoop(nums);

            // Assert
            Assert.That(highestNum, Is.EqualTo(expectedResult));
        }

        #endregion

        #region CONTROL FLOW TESTS

        [TestCase(50, "You failed.")]
        [TestCase(68, "You passed.")]
        [TestCase(93, "You passed with distinction!")]
        public void GivenPercentageScore_GetGrade_ReturnsGrade(int percentage, string expectedResult)
        {

            // Arrange


            // Act
            string grade = Program.GetGrade(percentage);

            // Assert
            Assert.That(grade, Is.EqualTo(expectedResult));

        }


        #endregion

        #region SWITCH-STATEMENT TESTS

        [TestCase(3, "Code Red")]
        [TestCase(2, "Code Amber")]
        [TestCase(1, "Code Amber")]
        [TestCase(0, "Code Green")]
        [TestCase(7, "Error")]
        [TestCase(-3, "Error")]
        public void GivenPriorityLevel_Priority_ReturnsPriorityCode(int level, string expectedResult)
        {
            // Arrange

            // Act
            string actualResult = Program.Priority(level);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }
        #endregion

    }
}