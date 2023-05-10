using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness;

public class InmemoryService : ICustomerService
{
    public List<Customer> db { get; set; } = new List<Customer>();
    public void Create(Customer c)
    {
        db.Add(c);
    }

    public Customer Read(string customerid)
    {
        var c = db.Find(e => e.CustomerId == customerid);
        if (c is null)
        {
            throw new ArgumentException($"{customerid} is not a valid ID");
        }
        return db.Find(c => c.CustomerId == customerid);
    }

    public List<Customer> ReadAll()
    {
        return db;
    }

    public void Remove(Customer c)
    {
        db.Remove(c);
    }

    public void SaveChanges()
    {
        
    }
}
