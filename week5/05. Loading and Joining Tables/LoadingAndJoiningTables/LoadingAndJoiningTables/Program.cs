using Microsoft.EntityFrameworkCore;

namespace LoadingAndJoiningTables;
public class Program
{
    static void Main()
    {
        using (NorthwindContext db = new())
        {
            var orderQuery = db.Orders.Where(o => o.Freight > 750).Include(o => o.Customer);    // Include == JOIN in SQL syntax

            // Above is, "In our database, db, Select all Orders where Freight > 750, join Customer to O

            foreach (var bigOrder in orderQuery)
            {
                Console.WriteLine(bigOrder.Customer.CompanyName);
            }
        }

        using (NorthwindContext db = new())
        {
            var orderQuery = db.Orders.Where(o => o.Freight > 750).Include(o => o.Customer).Include(o => o.OrderDetails).ThenInclude(od => od.Product);    // Include == JOIN in SQL syntax

            // Above is, "In our database, db, Select all Orders where Freight > 750, join Customer to O

            foreach (var bigOrder in orderQuery)
            {
                Console.WriteLine(bigOrder.Customer.CompanyName);

                foreach (var orderDetail in bigOrder.OrderDetails)
                {
                    Console.WriteLine($"\t {orderDetail.ProductId} {orderDetail.Product.ProductName}");
                }
            }
        }
    }
}
