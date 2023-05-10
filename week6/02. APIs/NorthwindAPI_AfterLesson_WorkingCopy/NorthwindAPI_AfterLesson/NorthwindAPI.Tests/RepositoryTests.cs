using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;

namespace NorthwindAPI.Tests;

public class RepositoryTests
{
    private NorthwindContext _context;
    private SuppliersRepository _sut;

    [OneTimeSetUp]

    public void OneTimeSetup()
    {
        var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase("NorthwindDB").Options;
        _context = new NorthwindContext(options);

        _sut = new SuppliersRepository(_context);
    }

    [SetUp]

    public void SetUp()

    {

        if (_context.Suppliers != null)

        {

            _context.Suppliers.RemoveRange(_context.Suppliers);

        }

        _context.Suppliers!.AddRange(

            new List<Supplier>

            {

                new Supplier

                {

                    SupplierId = 1,

                    CompanyName = "Sparta Global",

                    City = "Birmingham",

                    Country = "UK",

                    ContactName = "Nish Mandal",

                    ContactTitle = "Manager"

                },

                new Supplier {

                    SupplierId = 2,

                    CompanyName = "Nintendo",

                    City = "Tokyo",

                    Country = "Japan",

                    ContactName = "Shigeru Miyamoto",

                    ContactTitle = "CEO"

                }

            });

        _context.SaveChanges();

    }
    
    [Category("Happy Path")]

    [Category("FindAsync")]

    [Test]

    public void FindAsync_GivenValidID_ReturnsCorrectSupplier()

    {

        var result = _sut.FindAsync(1).Result;

        Assert.That(result, Is.Not.Null);

        Assert.That(result, Is.TypeOf<Supplier>());

        Assert.That(result.CompanyName, Is.EqualTo("Sparta Global"));

    }
    
}



