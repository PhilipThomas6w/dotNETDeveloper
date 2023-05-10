using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Security.Cryptography.X509Certificates;

namespace NorthwindTests;

public class CustomerManagerShould    
{
    private CustomerManager _sut;   // _sut = subject under test

    // 1. Let's make a dummy

    [Test]
    public void BeAbleToBeConstructed()
    {
        _sut = new CustomerManager(new Mock<ICustomerService>().Object);
        Assert.That(_sut, Is.TypeOf<CustomerManager>());
        Assert.That(_sut, Is.Not.Null);
    }

    [Test]
    [Category("Happy Path")]
    public void ReturnTrue_WhenUpdateIsCalledWithValidId() // dummy
    {
        // arrange

        var mockCustomerService = new Mock<ICustomerService>();
        
        var customerToUpdate = new Customer() { CustomerId = "BOB", ContactName = "Bob Marley", City = "Kingston" };

        mockCustomerService.Setup(cs => cs.Read("BOB")).Returns(customerToUpdate);  // () is the dummy stub

        _sut = new CustomerManager(mockCustomerService.Object);

        // act

        var result = _sut.Update("BOB", It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<string>());

        Assert.That(result, Is.True);
    }
    
    [Test]
    [Category("Happy Path")]
    public void UpdateSelectedCustomer_WhenUpdateIsCalledWithValidId() // dummy
    {
        // arrange

        var mockCustomerService = new Mock<ICustomerService>();
        
        var customerToUpdate = new Customer() { CustomerId = "BOB", ContactName = "Bob Marley", City = "Kingston" };

        mockCustomerService.Setup(cs => cs.Read("BOB")).Returns(customerToUpdate);  // () is the dummy stub

        _sut = new CustomerManager(mockCustomerService.Object);

        // act

        _sut.Update("BOB", "Robert Marley", "Port Royal",
            "PO51 C0D3", It.IsAny<string>());

        Assert.That(_sut.SelectedCustomer.ContactName, Is.EqualTo("Robert Marley"));
        Assert.That(_sut.SelectedCustomer.City, Is.EqualTo("Port Royal"));
        Assert.That(_sut.SelectedCustomer.Country, Is.EqualTo("Jamaica"));
        Assert.That(_sut.SelectedCustomer.PostalCode, Is.EqualTo("PO51 C0D3"));
    }

    [Test]
    public void ReturnFalse_GivenInvalidId()
    {
        // arrange

        var mockCustomerService = new Mock<ICustomerService>();

        mockCustomerService.Setup(cs => cs.Read("INVALID")).Throws<ArgumentException>();
        
        //mockCustomerService.Setup(cs => cs.Read("INVALID")).Returns((Customer)null);

        _sut = new CustomerManager(mockCustomerService.Object);

        // act

        var result = _sut.Update("INVALID", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        Assert.That(result, Is.False);
    }
    
    [Test]
    public void ReturnFalse_WhenThereIsADatabaseSaveException()
    {
        // arrange

        var mockCustomerService = new Mock<ICustomerService>();

        var customerToUpdate = new Customer() { CustomerId = "BOB", ContactName = "Bob Marley", City = "Kingston" };

        mockCustomerService.Setup(cs => cs.Read("BOB")).Returns(customerToUpdate);
        mockCustomerService.Setup(cs => cs.SaveChanges()).Throws<Exception>();
        
        _sut = new CustomerManager(mockCustomerService.Object);

        // act

        var result = _sut.Update("BOB", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        Assert.That(result, Is.False);
    }

    [Test]
    public void RemovesCustomer_WhenDeleteIsCalledWithValidId()
    {
        // arrange

        var mockCustomerService = new Mock<ICustomerService>();
        var customerToBeDeleted = new Customer() { CustomerId = "BOB", ContactName = "Bob Marley", City = "Kingston" };

        // testing delete by simulating methods returned by Remove call. The way these returns are simulated is called a stub.
        // Returns() has to return same object type as the read method
        mockCustomerService.Setup(cs => cs.Read("BOB")).Returns(customerToBeDeleted);
        mockCustomerService.Setup(cs => cs.Remove(customerToBeDeleted));

        // act

        _sut = new CustomerManager(mockCustomerService.Object);

        // Assert

        var result = _sut.Delete("BOB");
        Assert.That(result, Is.True);

    }

    [Test]

    public void CallSaveChanges_WhenUpdateIsCalled_WithValidId()
    {
        // arrange

        var mockCustomerService = new Mock<ICustomerService>();
        mockCustomerService.Setup(cs => cs.Read("MATT")).Returns(new Customer());
        _sut = new CustomerManager(mockCustomerService.Object);

        // act 

        _sut.Update("MATT", "", "", "", "");

        // Assert

        mockCustomerService.Verify(cs => cs.SaveChanges(), Times.AtLeastOnce());

        // Assert.Pass();


    }



}
