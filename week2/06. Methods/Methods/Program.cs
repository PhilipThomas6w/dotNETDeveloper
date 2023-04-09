namespace MethodsApp;

public class Program
{
    static void Main()
    {
        int returnedValue = DoThis(4, "ill");
        returnedValue = DoThis(4, "sleepy");

        string example = "this is an example";
        returnedValue = DoThis(4, example);

        Console.WriteLine(OrderPizza(pineapple: false, anchovies: true, mushrooms: true));

        var myTuple = (firstName: "John", lastName: "Smith", age: 33);
        Console.WriteLine(myTuple.firstName + " " + myTuple.lastName + " is " + myTuple.age);
        Console.WriteLine($"{myTuple.firstName} {myTuple.lastName} is {myTuple.age}");

        bool tryParseSuccess = Int32.TryParse("twelve", out int parsedString); // if the parse is successful, the parsed value will be stored in the out variable i.e., parsedString, but this won't be returned. The return value will be a bool (false in this case) and it will be stored in tryParseSuccess.
        Console.WriteLine(tryParseSuccess); 

        bool success = MyTryParse("66", out int myOutput);

        Console.WriteLine(DaysAndWeeks(323));
        
    }

    private static bool MyTryParse(string toBeParsed, out int myOutput)
    {
        myOutput = 10;
        return false;
    }

    private static (string firstName, string lastName, int age) makeAPerson(string fName, string lName, int years)
    {
        return (firstName: fName, lastName: lName, age: years);
    }


    private static int DoThis(int x, string y = "happy")
    {
        Console.WriteLine("I'm feeling " + y);
        return x * x;
    }

    public static string OrderPizza(bool anchovies, bool pineapple, bool mushrooms = false)
    {
        var pizza = "Pizza with tomatoa sauce, cheese, ";
        if (anchovies) pizza += "anchovies, ";
        if (pineapple) pizza += "pineapple, ";
        if (mushrooms) pizza += "mushrooms, ";
        return pizza;
    }

    public static (int numOfWeeks, int daysLeftOver) DaysAndWeeks(int numOfDays)
    {
        int numOfWeeks = numOfDays / 7;
        int daysLeftOver = numOfDays & 7;
        return (numOfWeeks, daysLeftOver);
    }


}
    
