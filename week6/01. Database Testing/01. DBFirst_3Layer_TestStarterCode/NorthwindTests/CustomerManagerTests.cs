using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;

namespace NorthwindTests
{
    public class CustomerTests
    {
        CustomerManager _customerManager;
        Customer testCustomer;

        [SetUp]
        public void Setup()
        {
            _customerManager = new CustomerManager();
            // remove test entry in DB if present
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }

            testCustomer = new Customer()  // object initializer
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
        public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
        {
            using (var db = new NorthwindContext())
            {
                int current = db.Customers.Count();
                _customerManager.Create(testCustomer.CustomerId, testCustomer.ContactName, testCustomer.CompanyName, testCustomer.City);
                db.SaveChanges();
                Assert.That(db.Customers.Count(), Is.EqualTo(current + 1));
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheirDetailsAreCorrect()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.Create(testCustomer.CustomerId, testCustomer.ContactName, testCustomer.CompanyName, testCustomer.City);
                db.SaveChanges();

                var addedCustomer = db.Customers.FirstOrDefault(c => c.CustomerId == "MANDA");
                Assert.That(addedCustomer, Is.Not.Null);
                Assert.That(addedCustomer.ContactName, Is.EqualTo(testCustomer.ContactName));
                Assert.That(addedCustomer.CompanyName, Is.EqualTo(testCustomer.CompanyName));
                Assert.That(addedCustomer.City, Is.EqualTo(testCustomer.City));
            }
        }

        [Test]
        public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.Create(testCustomer.CustomerId, testCustomer.ContactName, testCustomer.CompanyName, testCustomer.City);
                db.SaveChanges();

                var updatedContactName = "Nelson Delos";
                var updatedCity = "Birmingham";
                var updatedPostalCode = "BH9 7FG";
                var updatedCountry = "UK";

                var customerUpdated = _customerManager.Update(testCustomer.CustomerId, updatedContactName, updatedCountry, updatedCity, updatedPostalCode);
                db.SaveChanges();

                var updatedCustomer = db.Customers.FirstOrDefault(c => c.CustomerId == "MANDA");
                Assert.That(customerUpdated, Is.True);
                Assert.That(updatedCustomer, Is.Not.Null);
                Assert.That(updatedCustomer.ContactName, Is.EqualTo(updatedContactName));
                Assert.That(updatedCustomer.CompanyName, Is.EqualTo(testCustomer.CompanyName));
                Assert.That(updatedCustomer.City, Is.EqualTo(updatedCity));
                Assert.That(updatedCustomer.PostalCode, Is.EqualTo(updatedPostalCode));
                Assert.That(updatedCustomer.Country, Is.EqualTo(updatedCountry));
            }
        }


        [Test]
        public void WhenACustomerIsUpdated_SelectedCustomerIsUpdated()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.Create(testCustomer.CustomerId, testCustomer.ContactName, testCustomer.CompanyName, testCustomer.City);
                db.SaveChanges();

                var updatedContactName = "Nelson Delos";
                var updatedCity = "Birmingham";
                var updatedPostalCode = "BH9 7FG";
                var updatedCountry = "UK";

                _customerManager.Update(testCustomer.CustomerId, updatedContactName, updatedCountry, updatedCity, updatedPostalCode);
                db.SaveChanges();

                var updatedCustomer = db.Customers.FirstOrDefault(c => c.CustomerId == "MANDA");
                Assert.That(updatedCustomer, Is.Not.Null);
                Assert.That(updatedCustomer.ContactName, Is.EqualTo(updatedContactName));
                Assert.That(updatedCustomer.City, Is.EqualTo(updatedCity));
            }
        }


        [Test]
        public void WhenACustomerIsNotInTheDatabase_Update_ReturnsFalse()
        {
            using (var db = new NorthwindContext())
            {
                var result = _customerManager.Update("INVAL", "John Doe", "USA", "Los Angeles", "12345");
                db.SaveChanges();
                Assert.That(result, Is.False);
            }
        }


        [Test]
        public void WhenACustomerIsDeleted_TheNumberOfCustomersDecreasesBy1()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.Create(testCustomer.CustomerId, testCustomer.ContactName, testCustomer.CompanyName, testCustomer.City);
                db.SaveChanges();

                int current = db.Customers.Count();
                _customerManager.Delete(testCustomer.CustomerId);
                db.SaveChanges();
                Assert.That(db.Customers.Count(), Is.EqualTo(current - 1));
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new NorthwindContext())
            {
                _customerManager.Create(testCustomer.CustomerId, testCustomer.ContactName, testCustomer.CompanyName, testCustomer.City);
                db.SaveChanges();

                _customerManager.Delete(testCustomer.CustomerId);
                db.SaveChanges();

                var deletedCustomer = db.Customers.FirstOrDefault(c => c.CustomerId == "MANDA");
                Assert.That(deletedCustomer, Is.Null);
            }
        }


        [TearDown]
        public void TearDown()
        {
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
    }
}