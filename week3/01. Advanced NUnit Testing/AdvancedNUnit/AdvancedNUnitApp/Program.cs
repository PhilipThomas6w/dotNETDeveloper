using System.Diagnostics.Metrics;

namespace AdvancedNUnitApp;

public class Program
{
    static void Main()
    {
        var subject = new Calculator();
        Console.WriteLine(subject.ToString());
    }
}