using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;
using System.Collections.Generic;
using System;

namespace NorthwindTests;

public class CustomerTests
{
    InmemoryService _inMemoryService = new InmemoryService();
    CustomerManager _customerManager;
    
    [SetUp]
    public void Setup()
    {
        _inMemoryService.db = new List<Customer>() {
            new Customer() {CustomerId = "MANDA"},
            new Customer() {CustomerId = "MATTH"}
        };

        _customerManager = new CustomerManager(_inMemoryService);
    }

    [Test]
    public void WhenANewCustomerIsAdded_TheNumberOfCustemersIncreasesBy1()
    {
        var countOfList = _inMemoryService.db.Count();
        _customerManager.Create("SPARP", "Peter Bellaby", "SpartaGlobal", "Birmingham" );

        // Assert
        Assert.That(_inMemoryService.db.Count(), Is.EqualTo(countOfList + 1)); 
    }

    [Test]
    public void WhenANewCustomerIsAdded_TheirDetailsAreCorrect()
    {
        // Create a new customer
        _customerManager.Create("SPARP", "Peter Bellaby", "SpartaGlobal", "Birmingham");

        var customerIsAdded = _inMemoryService.db.Find(c => c.CustomerId == "SPARP");

        Assert.That(customerIsAdded.CustomerId, Is.EqualTo("SPARP"));
        Assert.That(customerIsAdded.ContactName, Is.EqualTo("Peter Bellaby"));
        Assert.That(customerIsAdded.CompanyName, Is.EqualTo("SpartaGlobal"));
        Assert.That(customerIsAdded.City, Is.EqualTo("Birmingham"));
    }

    [Test]
    public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
    {
        _customerManager.Create("SPARP", "Peter Bellaby", "SpartaGlobal", "Birmingham");

        var updatedCustomerId = "SPARP";
        var updatedContactName = "Matthew Handley";
        var updatedCountry = "UK";
        var updatedCity = "Stoke";
        var updatedPostcode = "ST76 4HY";

        var customerUpdated = _customerManager.Update(updatedCustomerId, updatedContactName, updatedCountry, updatedCity, updatedPostcode);

        var customerDetails = _inMemoryService.Read("SPARP");
        
        Assert.That(customerDetails.Country, Is.EqualTo(updatedCountry));
        Assert.That(customerDetails.ContactName, Is.EqualTo(updatedContactName));
        Assert.That(customerDetails.PostalCode, Is.EqualTo(updatedPostcode));
        Assert.That(customerDetails.City, Is.EqualTo(updatedCity));
    }

    [Test]
    public void WhenACustomerIsUpdated_SelectedCustomerIsUpdated()
    {
        _customerManager.Create("SPARP", "Peter Bellaby", "SpartaGlobal", "Birmingham");

        var updatedCustomerId = "SPARP";
        var updatedContactName = "Matthew Handley";
        var updatedCountry = "UK";
        var updatedCity = "Stoke";
        var updatedPostcode = "ST76 4HY";

        var customerUpdated = _customerManager.Update(updatedCustomerId, updatedContactName, updatedCountry, updatedCity, updatedPostcode);

        var udSelectedCustomer = _customerManager.SelectedCustomer;

        Assert.That(udSelectedCustomer.CustomerId, Is.EqualTo(updatedCustomerId));
        Assert.That(udSelectedCustomer.ContactName, Is.EqualTo(updatedContactName));
        Assert.That(udSelectedCustomer.Country, Is.EqualTo(updatedCountry));
        Assert.That(udSelectedCustomer.City, Is.EqualTo(updatedCity));
        Assert.That(udSelectedCustomer.PostalCode, Is.EqualTo(updatedPostcode));
    }

    [Test]
    public void WhenACustomerIsNotInTheDatabase_Update_ReturnsFalse()
    {
        var updatedCustomerId = "HYGTF";
        var updatedContactName = "Buck Rogers";
        var updatedCountry = "USA";
        var updatedCity = "New Jersey";
        var updatedPostcode = "NJ90210";

        var customerUpdated = _customerManager.Update(updatedCustomerId, updatedContactName, updatedCountry, updatedCity, updatedPostcode);

        Assert.That(customerUpdated, Is.False);
    }

    [Test]
    public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
    {
        var countOfList = _inMemoryService.db.Count();
        _customerManager.Delete("MANDA");

        // Assert
        Assert.That(_inMemoryService.db.Count(), Is.EqualTo(countOfList - 1));
    }

    [Test]
    public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
    {
        _customerManager.Delete("MANDA");
        Assert.That(_inMemoryService.db.Find(c => c.CustomerId == "MANDA"), Is.Null);
    }

    [TearDown]
    public void TearDown()
    {
        _inMemoryService.db = new List<Customer>() {
            new Customer() {CustomerId = "MANDA"},
            new Customer() {CustomerId = "MATTH"}
        };
    }
}