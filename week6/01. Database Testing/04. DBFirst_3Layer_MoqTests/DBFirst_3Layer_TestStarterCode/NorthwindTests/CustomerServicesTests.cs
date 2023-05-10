using Microsoft.EntityFrameworkCore;
using NorthwindBusiness;
using NorthwindData;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore.InMemory;

namespace NorthwindTests;

public class CustomerServiceTests
{
    private CustomerService _sut;
    private NorthwindContext _context;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var options = new DbContextOptionsBuilder<NorthwindContext>().UseInMemoryDatabase(databaseName: "Example_Db").Options;
        _context = new NorthwindContext(options);
        _sut = new CustomerService(_context);

        _context.Customers.Add(new Customer() { CustomerId = "JACOB", ContactName = "Jacob Banyard", City = "Beijing", CompanyName = "SpartaGlobal" });
        _context.Customers.Add(new Customer() { CustomerId = "DANIM", ContactName = "Danielle Massey", City = "Reykjavik", CompanyName = "SpartaGlobal" });
        _context.SaveChanges();
    }
    [Test]
    public void GivenValidID_Read_ReturnsCustomer()
    {
        var c = _sut.Read("JACOB");



        Assert.That(c, Is.Not.Null);
        Assert.That(c, Is.TypeOf<Customer>());
        Assert.That(c.ContactName, Is.EqualTo("Jacob Banyard"));
        Assert.That(c.CompanyName, Is.EqualTo("SpartaGlobal"));
        Assert.That(c.City, Is.EqualTo("Beijing"));
    }

}