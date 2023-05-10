using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;
using NorthwindAPI.Services;

namespace NorthwindAPI.Tests
{
    public class SupplierServiceShould
    {
       
        [Category("Happy Path")]

        [Category("GetSuppliers")]

        [Test]

        public async Task GetAllAsync_WhenThereAreSuppliers_ReturnsListOfSuppliers()

        {

            var mockRepository = GetRepository();

            var mockLogger = GetLogger();

            List<Supplier> suppliers = new List<Supplier> { It.IsAny<Supplier>() };

            Mock

                .Get(mockRepository)

                .Setup(sc => sc.GetAllAsync().Result)

                .Returns(suppliers);

            Mock

                .Get(mockRepository)

                .Setup(sc => sc.IsNull)

                .Returns(false);



            var _sut = new NorthwindService<Supplier>(mockLogger, mockRepository);

            var result = await _sut.GetAllAsync();

            Assert.That(result, Is.InstanceOf<IEnumerable<Supplier>>());

        }



        private static ILogger<INorthwindService<Supplier>> GetLogger()

        {

            return Mock.Of<ILogger<INorthwindService<Supplier>>>();

        }



        private static INorthwindRepository<Supplier> GetRepository()

        {

            return Mock.Of<INorthwindRepository<Supplier>>();

        }



    }
}
