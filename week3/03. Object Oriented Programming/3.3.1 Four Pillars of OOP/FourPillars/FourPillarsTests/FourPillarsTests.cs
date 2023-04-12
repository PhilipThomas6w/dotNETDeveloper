using FourPillarsApp;
using System;

namespace FourPillarsTests;

public class ClassStructsTests
{
    Person _sut;

    [Test]
    [Category("Constructor Tests")]
    public void GivenNoArguments_Person_IsCreated()
    {
        // Act
        _sut = new Person();

        //Assert
        Assert.Pass();
    }

    [Test]
    [Category("Constructor Tests")]
    public void GivenFirstNameLastName_Person_IsCreated()
    {
        // Act
        _sut = new Person("John", "Smith");

        //Assert
        Assert.Pass();
    }

    [Test]
    [Category("Constructor Tests")]
    public void GivenFirstNameLastNameAge_Person_IsCreatedWithAge()
    {
        // Act
        _sut = new Person("John", "Smith", 34);

        //Assert
        Assert.That(_sut.Age, Is.EqualTo(34));
    }

    [Test]
    [Category("Constructor Tests")]
    public void GivenFirstNameLastNameAgeHeight_Person_IsCreatedWithAgeAndHeight()
    {
        // Act
        _sut = new Person("John", "Smith", 34, 180);

        //Assert
        Assert.That(_sut.Height, Is.EqualTo(180));
    }

    [Test]
    [Category("Method Tests")]
    public void GivenConstructor1_GetFullName_ReturnsCorrectFullName()
    {
        // Arrange
        Person testPerson = new Person("John", "Smith");

        // Act
        string actualResult = "John Smith";

        //Assert
        Assert.That(actualResult, Is.EqualTo(testPerson.GetFullName()));
    }

    [Test]
    [Category("Method Tests")]
    public void GivenConstructor1_GetFullName_ReturnsTitleFullName()
    {
        // Arrange
        Person testPerson = new Person("John", "Smith");

        // Act
        string actualResult = "Mr John Smith";

        //Assert
        Assert.That(actualResult, Is.EqualTo(testPerson.GetFullName("Mr")));
    }

    [Test]
    [Category("Property Tests")]
    public void GivenSetAge_Get_ReturnsAge()
    {
        // Arrange
        Person testPerson = new Person("John", "Smith");
        testPerson.Age = 34;

        // Act
        var _age = testPerson.Age;


        //Assert
        Assert.That(_age, Is.EqualTo(testPerson.Age));
    }

}