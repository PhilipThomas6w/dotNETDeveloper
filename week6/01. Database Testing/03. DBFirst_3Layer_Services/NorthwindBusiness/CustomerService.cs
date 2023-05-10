using Microsoft.EntityFrameworkCore;
using NorthwindData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness;

public class CustomerService : ICustomerService, IDisposable
{
    private NorthwindContext _context;

    public CustomerService(NorthwindContext context) // constructor
    { 
        _context = context;
    }

    public CustomerService()
    {
        _context = new NorthwindContext();  // default constructor
    }
    
    public void Create(Customer c)
    {
        _context.Customers.Add(c);
        SaveChanges();
    }

    public Customer? Read(string customerId)
    {
        return _context.Customers.Find(customerId);
    }

    public List<Customer> ReadAll()
    {
        return _context.Customers.ToList();
    }

    public bool Update(Customer c)
    {
        var customerToUpdate = Read(c.CustomerId);
        if (customerToUpdate == null)
        {
            return false;
        }
        customerToUpdate.CustomerId = c.CustomerId;
        customerToUpdate.ContactName = c.ContactName;
        customerToUpdate.Country = c.Country;
        customerToUpdate.City = c.City;
        customerToUpdate.PostalCode = c.PostalCode;
       
        return SaveChanges();
    }

    public bool Delete(Customer c)
    {
        try
        {
            _context.Customers.Remove(c);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Error removing customer {e.Message}");
            return false;
        }

        return SaveChanges();
    }

    public bool SaveChanges()
    {

        try
        {
            _context.SaveChanges();
            return true;
        } 
        catch (Exception e)
        {
            Debug.WriteLine($"Error saving changes {e.Message}");
            return false;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
