using UnitTestLessonApp;

namespace UnitTestLessonTests;

public class Tests
{
    // [TestCase(timeOfDay, expectedMessage)]

    [TestCase(0, "Good evening!" )]
    
    /* 
    [TestCase(1, "Good morning!")]
    [TestCase(2, "Good morning!")]
    [TestCase(3, "Good morning!")]
    [TestCase(4, "Good morning!")]
    [TestCase(5, "Good morning!")]*/
    [TestCase(6, "Good morning!")]

    /*[TestCase(7, "Good morning!")]
    [TestCase(8, "Good morning!")]
    [TestCase(9, "Good morning!")]
    [TestCase(10, "Good morning!")]
    [TestCase(11, "Good morning!")]
    */
    
    [TestCase(12, "Good afternoon!")]
    

    /*[TestCase(13, "Good afternoon!")]
    [TestCase(14, "Good afternoon!")]
    [TestCase(15, "Good afternoon!")]
    [TestCase(16, "Good afternoon!")]
    [TestCase(17, "Good afternoon!")]
    */


   /*
    [TestCase(18, "Good evening!")]
    [TestCase(19, "Good evening!")]
    [TestCase(20, "Good evening!")]
   */
    [TestCase(21, "Good evening!")]
    
    /*
    [TestCase(22, "Good evening!")]
    [TestCase(23, "Good evening!")]
    */
    

    public void GetMessageTest(int timeOfDay, string expectedMessage)

    {
        // Arrange
        
        // Act
        string actualMessage = Program.GetMessage(timeOfDay);

        // Assert
        Assert.That(expectedMessage, Is.EqualTo(actualMessage));
       
    }
}