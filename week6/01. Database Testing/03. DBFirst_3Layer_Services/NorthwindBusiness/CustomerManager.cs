using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NorthwindData;

namespace NorthwindBusiness;

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

    public void Create(string customerId, string contactName, string companyName, string city = null)
    {
        var newCust = new Customer() { CustomerId = customerId, ContactName = contactName, CompanyName = companyName, City = city };
        _service.Create(newCust);
    }

    public Customer Read(string customerId)
    {
        return _service.Read(customerId);
    }

    public List<Customer> ReadAll()
    {
        return _service.ReadAll();
    }

    public bool Update(string customerId, string contactName, string country, string city, string postcode)
    {
        var customer = new Customer()
        {
            CustomerId = customerId,
            ContactName = contactName,
            Country = country,
            City = city,
            PostalCode = postcode
        };
        
        SelectedCustomer = customer;
        return _service.Update(customer);
        
    }

    public bool Delete(string customerId)
    {
        try
        {
            var customer = _service.Read(customerId);
            _service.Delete(customer);
            SelectedCustomer = null;
        }
        catch (ArgumentException e)
        {
            Debug.WriteLine($"Customer {customerId} not found");
            return false;
        }
        return true;

    }
}
