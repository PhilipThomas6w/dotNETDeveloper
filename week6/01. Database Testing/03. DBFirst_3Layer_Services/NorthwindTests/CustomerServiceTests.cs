using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using NorthwindData;
using NorthwindBusiness;

namespace NorthwindTests;

public class CustomerServiceTests
{
    private CustomerService _sut;
    private NorthwindContext _context;
    private Customer _testCustomer;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<NorthwindContext>().UseInMemoryDatabase(databaseName : "Example_DB").Options;
        
        _context = new NorthwindContext(options);
        _sut = new CustomerService(_context);

        // seed the in-memory database with some test data

        _context.Customers.Add(new Customer() { CustomerId = "JACOB", ContactName = "Jacob Banyard", City = "Beijing", CompanyName = "SpartaGlobal" });
        _context.Customers.Add(new Customer() { CustomerId = "DANIM", ContactName = "Danielle Massey", City = "Reykjavik", CompanyName = "SpartaGlobal" });


       _testCustomer = new Customer()  // object initializer
        {
            CustomerId = "MANDA",
            ContactName = "Amanda Delos",
            CompanyName = "Mandela Effect Ltd.",
            City = "Manchester",
            PostalCode = "M16 0SZ",
            Country = "UK"
        };
    }

    [Test]
    public void GivenValidID_Read_ReturnsCustomer()
    {
        // arrange

        // act
        var c = _sut.Read("Jacob");

        // assert
        Assert.That(c, Is.Not.Null);
        Assert.That(c, Is.TypeOf<Customer>());
        Assert.That(c.ContactName, Is.EqualTo("Jacob Banyard"));
        Assert.That(c.CompanyName, Is.EqualTo("SpartaGlobal"));
        Assert.That(c.City, Is.EqualTo("Beijing"));

    }

    [Test]
    public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
    {
        var currentTotal = _sut.ReadAll().Count();
        _context.Customers.Add(_testCustomer);
        Assert.That(_sut.ReadAll().Count(), Is.EqualTo(currentTotal + 1));
    }

    [Test]
    public void GivenNewCustomerIsAdded_Create_AddsCustomerDetailsCorrectly()
    {
        current
        Assert.That(_testCustomer.CustomerId), Is.EqualTo(currentCustomer.CustomerId));

        
    }

    [Test]
    public void WhenANewCustomerIsAdded_TheirDetailsAreCorrect()
    {
        using (var db = new NorthwindContext())
        {
            _customerManager.Create(testCustomer.CustomerId, testCustomer.ContactName, testCustomer.CompanyName, testCustomer.City);
            db.SaveChanges();

            var addedCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == "MANDA");
            Assert.That(addedCustomer, Is.Not.Null);
            Assert.That(addedCustomer.ContactName, Is.EqualTo(testCustomer.ContactName));
            Assert.That(addedCustomer.CompanyName, Is.EqualTo(testCustomer.CompanyName));
            Assert.That(addedCustomer.City, Is.EqualTo(testCustomer.City));
        }
    }

    [Test]
    public void WhenACustomerIsRemoved_()
    {

    }


    [TearDown]
    public void TearDown()
    {
        var selectedCustomers =
            from c in _context.Customers
            where c.CustomerId == "MANDA"
            select c;

        _context.Customers.RemoveRange(selectedCustomers);
        _context.SaveChanges();
    }

}
