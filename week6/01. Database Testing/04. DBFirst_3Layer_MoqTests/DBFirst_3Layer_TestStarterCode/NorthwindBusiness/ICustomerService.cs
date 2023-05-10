using System;
using NorthwindData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness;

public interface ICustomerService
{
    public List<Customer> ReadAll();
    public void Create(Customer c);
    public void Remove(Customer c);
    public void SaveChanges();
    public Customer Read(string customerid);

}
