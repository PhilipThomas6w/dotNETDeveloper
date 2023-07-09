namespace InheritanceLab.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void GivenArgumentOf3_Move_ReturnsExpectedValue()
        {
            // Arrange
            var a = new Airplane(200, 100, "JetsRUs") { NumPassengers = 150 };
            a.Ascend(500);
            var expectedValue = "Moving along 3 times at an altitude of 500 metres.";

            // Act
            var actualValue = a.Move(3);

            // Assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void GivenArgumentOf3_ToString_ReturnsExpectedValue()
        {
            // Arrange
            var a = new Airplane(200, 100, "JetsRUs") { NumPassengers = 150 };
            a.Ascend(500);
            a.Move(3);
            var expectedValue = "Thank you for flying JetsRUs: InheritanceLab.Airplane capacity: 200 passengers: 150 speed: 100 position: 300 altitude: 500.";

            // Act
            var actualValue = a.ToString();

            // Assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}