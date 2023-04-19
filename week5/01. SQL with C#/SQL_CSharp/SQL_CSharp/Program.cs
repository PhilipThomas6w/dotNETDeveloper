using System.Data.SqlClient;

namespace SQL_CSharp;

public class Program
{
    static void Main()
    {
        // created a new connection object from the SQLConnection class
        using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;
                                                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                                    MultiSubnetFailover=False"))
        {
            var customers = new List<Customer>();
            connection.Open(); // won't run without a connection string that points the connection object towards a database

            Console.WriteLine(connection.State);

            //READ

            var query = "SELECT * FROM CUSTOMERS";

            using (var command = new SqlCommand(query, connection))
            {
                var sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    var customer = new Customer();
                    customer.CompanyName = sqlReader["CompanyName"].ToString();
                    customer.City = sqlReader["City"].ToString();
                    customer.ContactName = sqlReader["ContactName"].ToString();
                    customer.ContactTitle = sqlReader["ContactTitle"].ToString();
                    customer.Region = sqlReader["Region"].ToString();
                    customer.CustomerID = sqlReader["CustomerID"].ToString();

                    customers.Add(customer);
                }

                sqlReader.Close();
            }

            //CREATE

            var newCustomer = new Customer()
            {
                CustomerID = "SPARP",
                CompanyName = "SpartaGlobal",
                ContactName = "Peter Bellaby",
                ContactTitle = "Junior Trainer",
                City = "Birmingham",
                Region = null
                
            };

            var createQuery = $"INSERT INTO CUSTOMERS (CustomerID, CompanyName, ContactName, ContactTitle, City, Region) " +
                $"VALUES ('{newCustomer.CustomerID}', '{newCustomer.CompanyName}', '{newCustomer.ContactName}', '{newCustomer.ContactTitle}', " +
                $"'{newCustomer.City}', '{newCustomer.Region ?? "NULL"}')";

            using (var createCommand = new SqlCommand(createQuery, connection))
            {
                //createCommand.ExecuteNonQuery();
            }

            //UPDATE

            var updateQuery = $"UPDATE CUSTOMERS SET City = 'Berlin' WHERE CustomerID = 'SPARP'";

            using (var updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.ExecuteNonQuery();
            }

            //DELETE
            var deleteQuery = $"DELETE FROM CUSTOMERS WHERE CustomerID = 'SPARP'";

            using (var deleteCommand = new SqlCommand(deleteQuery, connection))
            {
                deleteCommand.ExecuteNonQuery();
            }
        
        }

      

    }
}