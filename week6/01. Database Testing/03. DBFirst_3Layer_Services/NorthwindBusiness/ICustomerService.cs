using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindData;

namespace NorthwindBusiness;

public interface ICustomerService
{
    public void Create(Customer c);

    public Customer Read(string customerId);
    
    public List<Customer> ReadAll();

    public bool Update(Customer c);

    public bool Delete(Customer c);

    public bool SaveChanges();
}




