namespace FilmClassificationsApp;

public class Classification_Tests
{
    [TestCase(6)]
    [TestCase(8)]
    [TestCase(11)]
    public void GivenAgeUnder12_AvailableClassifications_ReturnsExpectedValue(int ageOfViewer)
    {
        // Arrange

        // Act
        string result = Program.AvailableClassifications(ageOfViewer);

        // Assert
        Assert.That(result, Is.EqualTo("U, PG & 12 films are available."));
    }

    [Test]
    public void GivenAgeUnder15_AvailableClassifications_ReturnsExpectedValue()
    {
        // Arrange
        int ageOfViewer = 13;

        // Act
        string result = Program.AvailableClassifications(ageOfViewer);

        // Assert
        Assert.That(result, Is.EqualTo("U, PG, 12 & 15 films are available."));
    }

    [Test]
    public void GivenAgeOver18_AvailableClassifications_ReturnsExpectedValue()
    {
        // Arrange
        int ageOfViewer = 20;

        // Act
        string result = Program.AvailableClassifications(ageOfViewer);

        // Assert
        Assert.That(result, Is.EqualTo("All films are available."));
    }

    [TestCase(-1)]
    [TestCase(140)]
    public void GivenOutOfRangeValue_AvailableClassifications_ReturnsArgumentOutOfRangeException(int ageOfViewer)
    {
        // Assert
        Assert.That(() => Program.AvailableClassifications(ageOfViewer), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    //[Test]
    //public void GivenNonIntegerValue_AvailableClassifications_ReturnsArgumentOutOfRangeException()
    //{
    //    // Arrange
    //    string ageOfViewer = "fifteen";

        
    //    // Assert
    //    Assert.That(() => Program.AvailableClassifications(int.Parse(ageOfViewer)), Throws.TypeOf<ArgumentException>());

    //}

    //[Test]
    //public void GivenNonIntegerValue_AvailableClassifications_ReturnsFormatException()
    //{
    //    // Arrange
    //    double ageOfViewer = 15.5;

    //    // Assert
    //    Assert.That(() => Program.AvailableClassifications(Convert.ToInt32(ageOfViewer)), Throws.TypeOf<FormatException>());

    //}
}