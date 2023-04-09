using AdvancedNUnitApp;

namespace AdvancedNUnitTests;

public class CalculatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]

    public void Add_Always_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 6;
        var subject = new Calculator { Num1 = 2, Num2 = 4 };

        // Act
        var result = subject.Add();
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult), "optional failure message");
    }

    [Test]

    public void SomeConstraints()
    {
        var _sut = new Calculator(); // _sut means "subject under test"
        _sut.Num1 = 2;
        _sut.Num1 = 4;

        Assert.That(_sut.IsDivisible());    // Assert that something is true or false
        _sut.Num2 = 3;
        Assert.That(_sut.IsDivisible(), Is.False);
        Assert.That(_sut.ToString(), Does.Contain("Calculator"));
    }

    [Test]
    public void StringConstraints()
    {
        var subject = new Calculator { Num1 = 2, Num2 = 4 };
        var strResult = subject.ToString();
        Assert.That(strResult, Is.EqualTo("AdvancedNUnit.Calculator"));
        Assert.That(strResult, Does.Contain("Calculator"));
        Assert.That(strResult, Does.Not.Contain("Potato"));
        Assert.That(strResult, Is.EqualTo("advancednunit.calculator").IgnoreCase);
        Assert.That(strResult, Is.Not.Empty);
    }

    [Test]
    public void TestRange()
    {
        Assert.That(8, Is.InRange(1, 10));
        List<int> nums = new List<int> { 4, 2, 7, 5, 9 };
        Assert.That(nums, Is.All.InRange(1, 10));
        Assert.That(nums, Has.Exactly(3).InRange(1, 5));
    }

    [Test]
    public void TestArrayOfStrings()
    {
        var fruit = new List<string> { "apple", "pear", "banana", "peach" };
        Assert.That(fruit, Does.Contain("pear")); 
        Assert.That(fruit, Has.Count.EqualTo(4)); 
        Assert.That(fruit, Has.Exactly(2).StartsWith("pea"));
    }

}