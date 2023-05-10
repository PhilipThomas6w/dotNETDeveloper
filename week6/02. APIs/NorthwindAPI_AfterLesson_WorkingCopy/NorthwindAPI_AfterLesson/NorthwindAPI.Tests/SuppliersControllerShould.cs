using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NorthwindAPI.Controllers;
using NorthwindAPI.Models;
using NorthwindAPI.Models.DTO;
using NorthwindAPI.Services;

namespace NorthwindAPI.Tests;

public class SuppliersControllerShould
{

    [Category("Happy Path")]

    [Category("GetSuppliers")]

    [Test]

    public async Task GetSuppliers_WhenThereAreSuppliers_ReturnsListOfSupplierDTOs()

    {

        var mockService = Mock.Of<INorthwindService<Supplier>>();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };

        Mock

            .Get(mockService)

            .Setup(sc => sc.GetAllAsync().Result)

            .Returns(suppliers);



        var sut = new SuppliersController(mockService);

        var result = await sut.GetSuppliers();

        Assert.That(result.Value, Is.InstanceOf<IEnumerable<SupplierDTO>>());

    }



}