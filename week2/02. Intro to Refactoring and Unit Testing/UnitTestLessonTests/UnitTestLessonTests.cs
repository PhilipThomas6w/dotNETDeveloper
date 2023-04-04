using UnitTestLessonApp;

namespace UnitTestLessonTests;

public class Tests
{
    // [Test] method

    [Test]

    public void Given13_GetMessage_ReturnsGoodAfternoon()
    {
        // Arrange
        int timeOfDay = 13;
        string expectedMessage = "Good afternoon!";

        // Act
        string actualMessage = Program.GetMessage(timeOfDay);

        // Assert
        Assert.That(actualMessage, Is.EqualTo(expectedMessage));
    }
    
    
    
    // [TestCase] method
    // [TestCase(timeOfDay, expectedMessage)]

    [TestCase(0, "Good evening!" )]
    [TestCase(6, "Good morning!")]
    [TestCase(12, "Good afternoon!")]
    [TestCase(21, "Good evening!")]

    public void Given13_GetMessage_ReturnsGoodAfternoon(int timeOfDay, string expectedMessage)
    {
        // Arrange
        
        // Act
        string actualMessage = Program.GetMessage(timeOfDay);

        // Assert
        Assert.That(expectedMessage, Is.EqualTo(actualMessage));
       
    }
}