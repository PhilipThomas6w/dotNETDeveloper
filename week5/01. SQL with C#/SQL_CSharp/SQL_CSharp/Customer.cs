namespace SQL_CSharp;

public class Customer
{
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string City { get; set; }
    public string? Region { get; set; }

    public string GetFullName()
    {
        return $"{ContactTitle} - {ContactName}";
    }

    public override string ToString()
    {
        return base.ToString() + $"{CustomerID} {CompanyName} {ContactName} {ContactTitle} {City} {Region}";
    }
}
