namespace LambdaExpressions;

public class Program
{
    static void Main()
    {
        // Lambda syntax
        // => goes into

        // given object => return the result of some expression
        // e.g., given x, return x * x
        // x => x * x

        List<int> numList = new() { 1, 2, 3, 5, 8, 13 };
        int countOfNums = numList.Count();

        
        // The result of the following foreach-loop...
        int countOfEvenNums = 0;
        foreach (int num in numList)
        {
            if (num % 2 == 0)
            {
                countOfEvenNums++;
            }
        }

        Console.WriteLine($"Result using foreach-loop: {countOfEvenNums}"); // should be 2

        // can be returned by the following statement using a lambda expression... 

        var countOfEvenNumsUsingLambdaExp = numList.Count(num => num % 2 == 0);

        Console.WriteLine($"Result using lambda expression: {countOfEvenNumsUsingLambdaExp}");

        // Query syntax vs. method syntax

        using (NorthwindContext db = new())
        {
            var query1UsingQuerySyntax =
                from c in db.Customers
                where c.City == "London"
                orderby c.ContactName
                select c;

            var query1UsingMethodSyntax = db.Customers.Where(c => c.City == "London").OrderBy(c => c.ContactName);   // select clause is implied when using method syntax

            foreach (var customer in query1UsingMethodSyntax)
            {
                Console.WriteLine($"{customer.ContactName} lives in {customer.City}");
            }

        }

        using (NorthwindContext db = new())
        {
            var productPerSupplierUsingQuerySyntax =
                from p in db.Products
                group p by p.SupplierId into productsOfASupplier
                select new { SupplierId = productsOfASupplier.Key, Products = productsOfASupplier.Count() };

            var productPerSupplierUsingMethodSyntax = db.Products.GroupBy(p => p.SupplierId).Select(
                productsOfASupplier => new 
                {
                SupplierId = productsOfASupplier.Key,
                Products = productsOfASupplier.Count()
                });

            foreach (var result in productPerSupplierUsingMethodSyntax)
            {
                Console.WriteLine($"Supplier ID: {result.SupplierId}, Number of Products: {result.Products}");
            }
        }
    }
    public static int SquareMe(int x)
    {
        return x * x;
    }
    public static int MyCount(List<int> list, Func<int, bool> condition)
    {
        int count = 0;

        foreach (var num in list)
        {
            if (condition(num))
            {
                count++;
            }
        }
        return count;
    }
}