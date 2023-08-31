using System.Data.SqlClient;

namespace UsingSqlClient;

public class Program
{
    static void Main()
    {
        // In this exercise, we demonstrate using System.Data.SqlClient to perform CRUD operations on a database.

        // A SqlConnection object represents a unique session to a SQL Server data source. Prefacing the SqlConnection object with a 'using' statement forces it to implement iDisposable() i.e., so that the object will be disposed of once the code inside the body {} has been executed. This allows us to disconnect from the database once the query has been executed.

        string connectionString = @"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        using (SqlConnection dbConnection = new SqlConnection(connectionString))

        //{
        //    dbConnection.Open(); // opens the database connection

        //    //Console.WriteLine(dbConnection.State); // reports the state of the database connection e.g., 'open'

        //    string query = "SELECT ContactName as 'Name' FROM CUSTOMERS";

        //    using (SqlCommand command = new(query, dbConnection))  // Creates an instance of SqlCommand to represent our query. It takes the query as the first argument and the connection object as the second argument. 
        //    {
        //        SqlDataReader dataReader = command.ExecuteReader(); // ExecuteReader() sends the query to the connection and builds an instance of SqlDataReader. An SqlDataReader object stores the records in a column as {key: value} pairs and provides a way of reading a forward-only stream of records from a SQL Server database.

        //        dataReader.Read();                                          // Reads the first record (row) stored in dataReader. Returns true if there are more records, else false.
        //        Console.WriteLine(dataReader["Name"].ToString());           // Returns the data stored in the dataReader as a string and prints it to console (i.e., "Maria Anders")

        //        dataReader.Read();                                          // Reads the second value stored in dataReader.                                          
        //        Console.WriteLine(dataReader["Name"].ToString());           // Prints "Ana Trujillo"

        //        // The above is an inefficient way of reading data from our table. A more efficient way is to create an object that models our table, as shown in the following example.

        //    }   // Connection will be closed once we exit this scope
        //}


        {
            dbConnection.Open();

            #region CREATE

            //Customer newCustomer = new()
            //{
            //    CustomerID = "WINGS",
            //    CompanyName = "SixWings",
            //    ContactName = "Luke Thomas",
            //    ContactTitle = "Operations Manager",
            //    City = "Shrewsbury",
            //    Region = null
            //};

            //string createQuery = $"INSERT INTO CUSTOMERS (CustomerID, CompanyName, ContactName, ContactTitle, City, Region) VALUES ('{newCustomer.CustomerID}', '{newCustomer.CompanyName}', '{newCustomer.ContactName}', '{newCustomer.ContactTitle}', '{newCustomer.City}', '{newCustomer.Region ?? "NULL"}')";

            //using (SqlCommand createCommand = new(createQuery, dbConnection))
            //{
            //    createCommand.ExecuteNonQuery();
            //}
            //// We have to comment this out so that we can run the code below i.e., we can't create this record twice.

            #endregion

            #region READ

            var customers = new List<Customer>();  // We can create store our returned values in a list

            string query = "SELECT * FROM CUSTOMERS";  // This is a T-SQL query; we want to select all from the Customers table

            using (SqlCommand command = new SqlCommand(query, dbConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())                                   // i.e., while there are more records...execute the block
                {
                    Customer customer = new();
                    customer.CustomerID = dataReader["CustomerID"].ToString();
                    customer.CompanyName = dataReader["CompanyName"].ToString();
                    customer.ContactName = dataReader["ContactName"].ToString();
                    customer.ContactTitle = dataReader["ContactTitle"].ToString();
                    customer.City = dataReader["City"].ToString();
                    customer.Region = dataReader["Region"].ToString();

                    customers.Add(customer);    // Adds each new customer to the customers list we declared above
                }

                dataReader.Close();
            }

            #endregion

            //#region UPDATE

            //string updateQuery = $"UPDATE CUSTOMERS SET City = 'Copenhagen' WHERE CustomerID = 'WINGS'";

            //using (SqlCommand updateCommand = new(updateQuery, dbConnection))
            //{
            //    updateCommand.ExecuteNonQuery();
            //}

            //#endregion

            #region DELETE

            string deleteQuery = $"DELETE FROM CUSTOMERS WHERE CustomerID = 'WINGS'";

            using (SqlCommand deleteCommand = new(deleteQuery, dbConnection))
            {
                deleteCommand.ExecuteNonQuery();
            }

            #endregion
        }
    }
}