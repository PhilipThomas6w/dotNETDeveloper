namespace EntityFrameworkWithLINQ;

public class Program
{
    static void Main()
    {
        List<int> myList = new() { 1, 3, 5, 7 };

        #region Simple query expressions

        IEnumerable<int> query =                             // query contains the "query expression", not the result of the query expression
            from number in myList
            where number > 4
            select number;

        // Queries are executed at Enumeration i.e., when you loop through them; this is known as "deferred execution".
        // Deferred execution allows us to defer the execution of a potentially slow operation (i.e., the query)

        List<int> filteredList = query.ToList();

        foreach (int number in filteredList)
        {
            Console.WriteLine(number);
        }

        using (NorthwindContext database = new NorthwindContext())
        {
            IEnumerable<Customer> londonCustomersQuery =
                 from customer in database.Customers
                 where customer.City == "London"
                 select customer;

            List<Customer> customersInLondon = londonCustomersQuery.ToList();
            foreach (var customer in customersInLondon)
            {
                Console.WriteLine($"{customer.ContactName} lives in {customer.City}");
            }
        }
        #endregion

        #region Using anonymous types in LINQ queries

        using (NorthwindContext database = new NorthwindContext())
        {
            IEnumerable<dynamic> employeeCityQuery =                         
                from employee in database.Employees
                where employee.City == "London" || employee.City == "Seattle"
                select new
                {
                    FullName = employee.FirstName + " " + employee.LastName,        // This is an anonymous type
                    City = employee.City
                };

            List<dynamic> employeesInLondonOrSeattle = employeeCityQuery.ToList();
            foreach (var employee in employeesInLondonOrSeattle)
            {
                Console.WriteLine($"{employee.FullName} lives in {employee.City}");
            }
        }
        
        using (NorthwindContext database = new NorthwindContext())
        {
            var londonBerlinCompanyandCountryQuery =
                // SELECT CompanyName, Country FROM Customers WHERE City IN ('London', 'Berlin')
                from c in database.Customers
                where c.City == "London" || c.City == "Berlin"
                select new { Company = c.CompanyName, Country = c.Country };

            foreach (var item in londonBerlinCompanyandCountryQuery)
            {
                Console.WriteLine(item.Company + " " + item.Country);
            }
        }

        #endregion

        using (NorthwindContext database = new NorthwindContext())
        {
            var top10ExpensiveProductsQuery =
                from p in database.Products
                orderby p.UnitPrice descending
                select new { Name = p.ProductName, Price = p.UnitPrice };

            foreach (var item in top10ExpensiveProductsQuery.Take(10))
            {
                Console.WriteLine(item.Name + " " + item.Price);
            }
        }
        
        using (NorthwindContext database = new NorthwindContext())
        {
            var productStockPerSupplierQuery =
                from p in database.Products
                group p by p.SupplierId into supplier
                select new { SupplierId = supplier.Key, UnitsInStock = supplier.Sum(p => p.UnitsInStock) };

            foreach (var item in productStockPerSupplierQuery)
            {
                Console.WriteLine(item.SupplierId + " " + item);
            }
        }



    }
}