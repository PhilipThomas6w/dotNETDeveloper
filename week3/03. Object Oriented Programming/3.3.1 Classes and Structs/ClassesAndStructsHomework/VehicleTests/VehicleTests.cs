using ClassesAndStructsHomework;

namespace VehicleTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void WhenADefaultVehicleMovesTwiceItsPositionIs20()
        {
            // Arrange
            var vehicle = new Vehicle();

            // Act
            var result = vehicle.Move(2);

            // Assert
            Assert.That(vehicle.Position, Is.EqualTo(20));
            Assert.That(result, Is.EqualTo("Moving along 2 times"));
        }

        [Test]
        public void WhenADefaultVehicleWithSpeed40IsMovedOnceItsPositionIs40()
        {
            // Arrange
            var vehicle = new Vehicle(5, 40);
            
            // Act
            var result = vehicle.Move();

            // Assert
            Assert.That(vehicle.Position, Is.EqualTo(40));
            Assert.That(result, Is.EqualTo("Moving along"));
        }
    }
}