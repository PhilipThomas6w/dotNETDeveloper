namespace MethodsApp;

public class Program
{
    static void Main()
    {
        //int returnedValue = DoThis(4);
        //returnedValue = DoThis(4, "sleepy");

        

        var daysAndWeeks = CalculateDaysAndWeeks(157);
        Console.WriteLine(daysAndWeeks);

    }

    //private static int DoThis(int x, string y = "happy")
    //{
    //    Console.WriteLine("I'm feeling " + y);
    //    return x * x;
    //}

    //public static string OrderPizza(bool anchovies, bool pineapple, bool mushrooms = false)
    //{
    //    var pizza = "Pizza with tomato sauce, cheese, ";
    //    if (anchovies) pizza += "anchovies, ";
    //    if (pineapple) pizza += "pineapple, ";
    //    if (mushrooms) pizza += "mushrooms, ";
    //    return pizza;
    //}

    public static string CalculateDaysAndWeeks(int days)
    {
        int numberOfWeeks = days / 7;
        int daysLeftOver = days - numberOfWeeks * 7;
        return $"There are {numberOfWeeks} weeks and {daysLeftOver} days.";
    }
}
