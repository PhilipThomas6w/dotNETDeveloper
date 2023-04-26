using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EntityFrameworkWithLambdaExpressions;

public class Program
{
    static void Main()
    {
        // Lambda syntax

        // input object => return the result of some expression
        // given x, return x * x
        // x => x * x;

        var nums = new List<int>() { 3, 7, 1, 2, 8, 3, 0, 4, 5 };
        var countOfNums = nums.Count();
        var countOfEvenNums = nums.Count(n => n % 2 == 0);
        var countOfOddNums = nums.Count(n => n % 2 == 1);
        Console.WriteLine($"Number of even numbers in nums list: {countOfEvenNums} \nNumber of odd numbers in nums list: {countOfOddNums}");


        // There are two common syntaxes used in Entity Framework, query syntax and method syntax
        
        using (var db = new NorthwindContext())
        {
            // Query syntax
            var customersInLondonUsingQuerySyntax =
                from c in db.Customers
                where c.City == "London"
                orderby c.ContactName
                select c;

            // Method syntax
            var customersInLondonUsingMethodSyntax = db.Customers.Where(c => c.City == "London").OrderBy(c => c.ContactName); // don't need a SELECT statement; Select.(c => c); is implied.

            
            // Query syntax
            var productPerSupplierUsingQuerySyntax =
                from p in db.Products
                group p by p.SupplierId into productsOfASupplier
                select new 
                { 
                    SupplierId = productsOfASupplier.Key, 
                    SupplierName = (from s in db.Suppliers where s.SupplierId == productsOfASupplier.Key select s.CompanyName).First(),
                    Products = productsOfASupplier.Count() 
                };

            // Method syntax
            var productPerSupplierQueryUsingMethodSyntax = db.Products.GroupBy(p => p.SupplierId).Select(
                    productsOfASupplier => new 
                    { 
                        SupplierId = productsOfASupplier.Key,
                        SupplierName = db.Suppliers.Where(s => s.SupplierId == productsOfASupplier.Key).Select(s => s.CompanyName).First(),
                        Products = productsOfASupplier.Count() 
                    }
                );

            foreach (var result in productPerSupplierQueryUsingMethodSyntax)
            {
                Console.WriteLine($"Supplier ID: {result.SupplierId} - Number of Products {result.Products}");
            }

            // Lazy loading via an EF setting




            // the above using query syntax
            //var ordersQuery2 =
            //    from o in db.Orders
            //    where o.Freight > 750
            //    join c in db.Customers on o.CustomerId equals c.CustomerId
            //    join od in db.OrderDetails on o.OrderId equals od.OrderId
            //    join p in db.Products on od.ProductId equals p.ProductId
            //    select o;

            //foreach (var bigOrder in ordersQuery2)
            //{
            //    Console.WriteLine(bigOrder.Customer.CompanyName);

            //    foreach (var orderDetail in bigOrder.OrderDetails)
            //    {
            //        Console.WriteLine($"\t {orderDetail.ProductId}) - {orderDetail.Product.ProductName}");
            //    }
            //}

            var customersAndSuppliersInTheSameCity = db.Customers.Join(db.Suppliers, c => c.City, s => s.City, (c, s) => new
            {
                Customer = c.ContactName,
                CustomerCompany = c.CompanyName,
                Supplier = s.CompanyName,
            });

            foreach (var result in customersAndSuppliersInTheSameCity)
            {
                Console.WriteLine($"The customer, {result.Customer}, from the company {result.CustomerCompany} is based near our supplier {result.Supplier}");
            }

        }





    }


    public static int SquareMe(int x)
    {
        return x * x;
    }



}