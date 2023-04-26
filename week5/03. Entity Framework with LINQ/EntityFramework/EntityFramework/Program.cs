namespace EntityFrameworkWithLINQ;

public class Program
{
    static void Main()
    {
        List<int> myList = new() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

        // listQuery stores a query, not what is returned from that query
        var listQuery =
            from number in myList
            where number > 4
            select number;

        // queries are executed in enumeration i.e., to get the result you need to loop through the list

        var myNewList = listQuery.ToList(); // The data returned by the query is stored in myNewList

        foreach (var num in listQuery)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine(myNewList[5]);

        using (var db = new NorthwindContext())
        {
            IEnumerable<Customer> londonCustomersQuery =
                from customer in db.Customers
                where customer.City == "London" || customer.City == "Berlin"
                select customer;

            var londonCustomers = londonCustomersQuery.ToList();

            foreach (var customer in londonCustomers)
            {
                Console.WriteLine($"{customer.ContactName} in {customer.City}");
            }

            var londonBerlinCompanyandCountryQuery =
                // SELECT CompanyName, Country FROM Customers WHERE City IN ('London', 'Berlin')
                from c in db.Customers
                where c.City == "London" || c.City == "Berlin"
                select new { Company = c.CompanyName, Country = c.Country };

            foreach (var item in londonBerlinCompanyandCountryQuery)
            {
                Console.WriteLine(item.Company + " " + item.Country);
            }

            var top10ExpensiveProductsQuery =
                from p in db.Products
                orderby p.UnitPrice descending
                select new { Name = p.ProductName, Price = p.UnitPrice };

            foreach (var item in top10ExpensiveProductsQuery.Take(10))
            {
                Console.WriteLine(item.Name + " " + item.Price);
            }

            var productStockPerSupplierQuery =
                from p in db.Products
                group p by p.SupplierId into supplier
                select new { SupplierId = supplier.Key, UnitsInStock = supplier.Sum(p => p.UnitsInStock) };
            // SELECT supplierId, Count(productId)
            // FROM Products
            // GROUP BY productId

            foreach (var item in productStockPerSupplierQuery)
            {
                Console.WriteLine(item.SupplierId + " " + item)
            }

        }


    }
}