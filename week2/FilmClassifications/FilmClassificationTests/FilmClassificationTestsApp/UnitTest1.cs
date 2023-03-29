namespace FilmClassificationsApp;

public class Classification_Tests
{
    [TestCase]
    public void TestAgeUnder12()
    {
        // Arrange
        int ageOfViewer = 10;

        // Act
        string result = Program.AvailableClassifications(ageOfViewer);

        // Assert
        Assert.That(result, Is.EqualTo("U, PG and 12 films are available."));
    }

    [TestCase]
    public void TestAgeUnder15()
    {
        // Arrange
        int ageOfViewer = 13;

        // Act
        string result = Program.AvailableClassifications(ageOfViewer);

        // Assert
        Assert.That(result, Is.EqualTo("U, PG, 12 and 15 films are available."));
    }

    [TestCase]
    public void TestAgeOver18()
    {
        // Arrange
        int ageOfViewer = 20;

        // Act
        string result = Program.AvailableClassifications(ageOfViewer);

        // Assert
        Assert.That(result, Is.EqualTo("All films are available."));
    }
}