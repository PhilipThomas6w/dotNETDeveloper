using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindData;

namespace NorthwindBusiness;

public class CustomerService : ICustomerService, IDisposable
{
    private NorthwindContext _db;

    public CustomerService(NorthwindContext context)
    {
        _db = context;
    }

    public CustomerService()
    {
        _db = new NorthwindContext();
    }
    public void Create(Customer c)
    {
        _db.Customers.Add(c);
        SaveChanges();
    }

    public Customer Read(string customerid)
    {
        var c = _db.Customers.Find(customerid);
        if (c is null)
        {
            throw new ArgumentException($"{customerid} is not a valid ID");
        }
       return c;
    }

    public List<Customer> ReadAll()
    {
        return _db.Customers.ToList();
    }

    public void Remove(Customer c)
    {
        _db.Customers.Remove(c);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _db.SaveChanges();
        Dispose();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
