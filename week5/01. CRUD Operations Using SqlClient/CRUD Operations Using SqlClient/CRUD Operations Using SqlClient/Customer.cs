namespace UsingSqlClient;

public class Customer
{
    public string CustomerID { get; set; }

    public string CompanyName { get; set; }

    public string ContactName { get; set; }

    public string ContactTitle { get; set; }

    public string City { get; set; }

    public string? Region { get; set; }     // Use ? to make string nullable

    // We often want to have helper functions on our models to manipulate or use the data that they model

    public string GetFullName()
    {
        return $"{ContactTitle} - {ContactName}";
    }

    public override string ToString()
    {
        return base.ToString() + $"{CustomerID}: {CompanyName}, {ContactName}, {ContactTitle}, {City}, {Region}.";
    }

}
