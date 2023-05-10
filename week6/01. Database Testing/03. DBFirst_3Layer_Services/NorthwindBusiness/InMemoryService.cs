using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindData;

namespace NorthwindBusiness;

public class InMemoryService : ICustomerService
{ 
    public List<Customer> db { get; set; } = new List<Customer>();

    public void Create(Customer c)
    {
        db.Add(c);
        SaveChanges();
    }

    public Customer Read(string customerId)
    {
        var customer =  db.Find(c => c.CustomerId == customerId);
        if (customer == null)
        {
            Debug.WriteLine($"Customer {customerId} not found");
            throw new ArgumentException();
        }
        else
        {
            return customer;
        }
    }

    public List<Customer> ReadAll()
    {
        return db;
    }

    public bool Delete(Customer c)
    {
        try
        {
            db.Remove(c);
        }
        catch ()
        {

        }
        SaveChanges();
    }

    public bool SaveChanges()
    {
        db.SaveChanges();
    }

    public bool Update(Customer c)
    {
        db.Update();
    }

}
