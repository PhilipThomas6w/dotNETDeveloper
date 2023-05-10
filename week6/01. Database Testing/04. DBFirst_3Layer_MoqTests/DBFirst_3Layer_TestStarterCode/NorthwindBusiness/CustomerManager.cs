using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NorthwindData;

namespace NorthwindBusiness
{
    public class CustomerManager
    {
        public Customer SelectedCustomer { get; set; }

        private ICustomerService _service;

        public CustomerManager()
        {
            _service = new CustomerService();
        }

        public CustomerManager(ICustomerService service)
        {
            _service = service;
        }

        public void SetSelectedCustomer(object selectedItem)
        {
            SelectedCustomer = (Customer)selectedItem;
        }

        public List<Customer> RetrieveAll()
        {
            return _service.ReadAll();
        }

        public void Create(string customerId, string contactName, string companyName, string city = null)
        {
            var newCust = new Customer() { CustomerId = customerId, ContactName = contactName, CompanyName = companyName, City = city };
            _service.Create(newCust);
        }

        public bool Update(string customerId, string contactName, string country, string city, string postcode)
        {
            try
            {
                var customer = _service.Read(customerId);
                customer.ContactName = contactName;
                customer.City = city;
                customer.PostalCode = postcode;
                customer.Country = country;
                try
                {
                    _service.SaveChanges();
                    SelectedCustomer = customer;
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Error updating {customerId}");
                    return false;
                }
            }
            catch(ArgumentException)
            {
                Debug.WriteLine($"Customer {customerId} not found");
                return false;
            }
            return true;
        }

        public bool Delete(string customerId)
        {
            try
            {
                var customer = _service.Read(customerId);
                _service.Remove(customer);
                SelectedCustomer = null;
            }
            catch(ArgumentException e)
            {
                Debug.WriteLine($"Customer {customerId} not found");
                return false;
            }
            return true;
        }
    }
}
