namespace eSQLWithEntityFramework;
public class Program
{
    static void Main()
    {

        // Instantiate the database object...
        
        using (NorthwindContext database = new())                       // Instantiates and connects to the database object
        {
            // CREATE

            // First we instantiate a new customer...
            Customer newCustomer = new() { CustomerId = "SPARP", CompanyName = "SpartaGlobal", ContactName = "Peter Bellaby" };

            // Then we add the customer to our database object

            database.Customers.Add(newCustomer);                        // generates and executes the SQL needed to propogate the changes
            database.SaveChanges();                                     // saves the changes

            // READ

            Console.WriteLine(database.ContextId);                      // prints the UID of the database

            foreach (var customer in database.Customers)                // iterates through each item in database.Customers
            {
                Console.WriteLine(customer.ContactName);                // prints each record in ContactName column on a new line
            }

            // UPDATE

            Customer customerToBeUpdated = database.Customers.Find("SPARP");
            customerToBeUpdated.City = "Birmingham";
            database.SaveChanges();

            // DELETE

            Customer customerToBeDeleted = database.Customers.Find("SPARP");
            database.Customers.Remove(customerToBeDeleted);

        } // Connection closes when we leave the scope of the using statement











    }
}