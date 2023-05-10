using System;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace UsingSqlClient;

public class Program
{
    static void Main()
    {
        // We use an instance of SqlConnection to establish a connection to our database by passing a connection string to it.
        // We use the using keyword so that we can disconnect from the database once we've retreived the data we queried

        using (SqlConnection connection1 = new SqlConnection(@"Data Source =.; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
        {
            connection1.Open();                                              // opens the connection

            //Console.WriteLine(connection1.State);                            // reports the state of the connection

            string query1 = "SELECT ContactName as 'Name' FROM CUSTOMERS";

            using (SqlCommand command = new(query1, connection1))  // create an instance of SqlCommand to represent our query. It takes the query as first argument and the connection object as the second argument. 
            {
                SqlDataReader dataReader = command.ExecuteReader();         // ExecuteReader() sends the query to the connection and builds an instance of SqlDataReader. An SqlDataReader object stores the records in a column as {key: value} pairs and provides a way of reading a forward-only stream of records from a SQL Server database.

                dataReader.Read();                                          // Reads the first record (row) stored in dataReader. Returns true if there are more records, else false.
                Console.WriteLine(dataReader["Name"].ToString());           // Returns the data stored in the dataReader as a string and prints it to console (i.e., "Maria Anders")

                dataReader.Read();                                          // Reads the second value stored in dataReader.                                          
                Console.WriteLine(dataReader["Name"].ToString());           // Prints "Ana Trujillo"

                // The above is an inefficient way of reading data from our table. A more efficient way is to create an object that models our table.

            }   // Connection will be closed once we exit this scope
        }

        using (SqlConnection connection2 = new SqlConnection(@"Data Source =.; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
        {
            List<Customer> customers = new();
            
            connection2.Open();

            #region READ

            string query2 = "SELECT * FROM CUSTOMERS";

            using (SqlCommand command2 = new SqlCommand(query2, connection2))
            {
                SqlDataReader dataReader = command2.ExecuteReader();

                while (dataReader.Read())                                   // i.e., while there are more records...
                {
                    Customer customer = new();
                    customer.CustomerID = dataReader["CustomerID"].ToString();
                    customer.CompanyName = dataReader["CompanyName"].ToString();
                    customer.ContactName = dataReader["ContactName"].ToString();
                    customer.ContactTitle = dataReader["ContactTitle"].ToString();
                    customer.City = dataReader["City"].ToString();
                    customer.Region = dataReader["Region"].ToString();

                    customers.Add(customer);
                }

                dataReader.Close();
            }

            #endregion

            #region CREATE

            //Customer newCustomer = new()
            //{
            //    CustomerID = "SPARP",
            //    CompanyName = "SpartaGlobal",
            //    ContactName = "Peter Bellaby",
            //    ContactTitle = "Junior Trainer",
            //    City = "Birmingham",
            //    Region = null
            //};

            //string createQuery = $"INSERT INTO CUSTOMERS (CustomerID, CompanyName, ContactName, ContactTitle, City, Region) " +
            //    $"VALUES ('{newCustomer.CustomerID}', '{newCustomer.CompanyName}', '{newCustomer.ContactName}', '{newCustomer.ContactTitle}', " +
            //    $"'{newCustomer.City}', '{newCustomer.Region ?? "NULL"}')";

            //using (SqlCommand createCommand = new(createQuery, connection2))
            //{
            //    createCommand.ExecuteNonQuery();
            //}
            // We have to comment this out so that we can run the code below; we can't create this record twice.

            #endregion

            #region UPDATE

            //string updateQuery = $"UPDATE CUSTOMERS SET City = 'Berlin' WHERE CustomerID = 'SPARP'";

            //using (SqlCommand updateCommand = new(updateQuery, connection2))
            //{
            //    updateCommand.ExecuteNonQuery();
            //}

            #endregion

            #region DELETE

            string deleteQuery = $"DELETE FROM CUSTOMERS WHERE CustomerID = 'SPARP'";

            using (SqlCommand deleteCommand = new(deleteQuery, connection2))
            {
                deleteCommand.ExecuteNonQuery();
            }

            #endregion
        }
    }
}