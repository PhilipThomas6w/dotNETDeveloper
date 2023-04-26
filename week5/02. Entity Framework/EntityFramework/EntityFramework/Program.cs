namespace EntityFramework;

public class Program
{
    static void Main()
    {
        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Make the database object and connect
        using (var db = new NorthwindContext())
        {
            Console.WriteLine(db.ContextId); // Getting the UID

            // Reading all customers
            foreach (var customer in db.Customers)
            {
                Console.WriteLine(customer.ContactName);
            }

            //// CREATE
            //var newCustomer = new Customer() { CustomerId = "SPARP", CompanyName = "SpartaGlobal", ContactName = "Peter Bellaby" };
            //// This just adds the newCustomer to our in memory list
            //db.Customers.Add(newCustomer);
            //// This does a lot of background work including generating the sql queries needed to propogate the changes and executing them
            //db.SaveChanges();

            // UPDATE

            //var selectedCustomer = db.Customers.Find("SPARP");

            //selectedCustomer.City = "Birmingham";

            //db.SaveChanges();

            //selectedCustomer = db.Customers.Find("SPARP");
            //Console.WriteLine(selectedCustomer.City);

            //// DELETE

            var customerToDelete = db.Customers.Find("SPARP");
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();

        }

    }
}