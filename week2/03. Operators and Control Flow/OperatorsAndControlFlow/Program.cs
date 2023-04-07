using System.Diagnostics;
using LoopExamples;

namespace OperatorsAndControlFlow;

public class Program
{
    static void Main()
    {
        Operators(); // This simply calls the Operators() method so that we can see results printed to the Console.

        Console.WriteLine(GetGrade(87)); // Body contains a conditional statement that uses a ternary operator

        try
        {
            Console.WriteLine("Matt's grade is " + GetGrade(-89));
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }

        // ###SWITCH STATEMENTS###

        Console.WriteLine(Priority(1)); // Body contains a switch statement

        Console.WriteLine(DrivingLaw(15)); // Body contains a switch statement that includes conditional logic

        // ###ITERATIONS (LOOPS)###

        List<int> nums = new List<int> { 10, 6, 22, -17, 3};

        Console.WriteLine("Highest number using a for loop: " + Loops.HighestForLoop(nums));
        Console.WriteLine("Highest number using a foreach loop: " + Loops.HighestForEachLoop(nums));
        Console.WriteLine("Highest number using a for loop: " + Loops.HighestWhileLoop(nums));
        Console.WriteLine("Highest number using a for loop: " + Loops.HighestDoWhileLoop(nums));

    }

    #region OPERATORS
    public static void Operators()
    {
        // ###PREFIX AND POSTFIX INCREMENT OPERATORS###

        int x = 5;
        int y = 5;

        int w = x++; // w = 5, x = 6 (the is because x is incremented last)
        Console.WriteLine($"The value of w is {w} and the value of x is {x}.");

        int z = ++y; // z = 6, y = 6 (this is because y is incremented first)
        Console.WriteLine($"The value of z is {z} and the value of y is {y}.");


        // ###VAR & INTEGER DIVISION###

        long l = 10_000_000_000;
        var n = 10;
        var s = "Hello";

        var pizzaSlices = 5;
        var pizzaEaters = 2;

        // How many *whole* pizzaSlices does each pizzaEater get?

        var portion = pizzaSlices / pizzaEaters;

        Console.WriteLine($"Each person can have {portion} whole slices of pizza");

        /* slicesPerEater is assigned a value of 2, not 2.5. Why?
           Because the result of the division is an integer, not a double. 
           To get a double, we need to cast one of the operands to a double.*/

        var portion2 = (double)pizzaSlices / pizzaEaters;

        Console.WriteLine($"Each person can have {portion2} slices of pizza");


        // ###MODULUS OPERATOR###
        // The modulus operator returns the remainder of a division operation.

        // Let's assume that each pizzaEater only eats 2 slices of pizza each. How many are left over?

        var slicesLeftOver = pizzaSlices % pizzaEaters;

        Console.WriteLine($"There are {slicesLeftOver} slices left over");

        // Similarly...

        int cadburyBar = 10;
        int children = 3;
        int numBarsPerChild = cadburyBar / children;
        int leftOverBars = cadburyBar % children;

        int days = 147;
        int numWeeks = days / 7;
        int numDaysLeftOver = days % 7;
        Console.WriteLine($"There are {numWeeks} weeks and {numDaysLeftOver} days left over.");


        // ###ASSIGNMENT OPERATORS###
        // Assignment operators are used to assign a value to a variable.

        x = 5;
        x = x + 10; // x is now 15
        x += 10; // x is now 25. i.e., x = x + 10 is the same as x += 10




        // ###CONDITIONAL EXPRESSIONS & LOGICAL OPERATORS###
        // Conditional expressions are used to evaluate a condition and return a value based on the result of the condition.

        bool isComfortable = numBarsPerChild >= 2 & leftOverBars > 0 | pizzaSlices < pizzaEaters;
        // isComfortable will be true if numBarsPerChild is greater than or equal to 2 AND leftOverBars is greater than 0,
        // OR pizzaSlices is less than pizzaEaters.



        // ###SHORT-CIRCUIT OPERATORS###

        /* Short-circuit operators are used to control the flow of logical expressions, by evaluating only the minimum
         * number of operands required to determine the result of the expression. There are two short-circuit operators in 
         * C#: the logical AND operator && and the logical OR operator ||.

         * The logical AND operator && evaluates the second operand only if the first operand evaluates to true.*/

        bool isWearingParachute = false;

        if (isWearingParachute && JumpsOutOfAirplane()) // JumpsOutOfAirplane() won't evaluate because isWearingParachute is false.
        {
            Console.WriteLine("You made a successful jump!");
        }
        else
        {
            Console.WriteLine("If you jump, you'll go splat!");
        }

        string greeting = "Allo allo";
        if (greeting != null && greeting.ToLower().StartsWith('a')) // The rhs will evaluate because the lhs is true.
        {
            Console.WriteLine(greeting + " starts with 'a'");
        }

    }
    private static bool JumpsOutOfAirplane()
    {
        Console.WriteLine("Weeeeee! I'm falling!");
        return true;
    }

    #endregion

    #region CONTROL FLOW

    public static void ControlFlow()
    { 
        //###TERNARY OPERATOR###

        int grade = 71;
        string result = "";

        if (grade >= 65)
        {
            result = "You passed!";
        }
        else
        {
            result = "You failed...";
        }

        // The if block above can be written more efficiently using the ternary operator...

        result = grade >= 65 ? "You pass!" : "You failed...";

        // You can also write nested loops using ternary operators, though this is not common as it can be difficult to read

        result = grade >= 65 ? (grade >= 85 ? "You passed with distinction!" : "You passed.") : "You failed...";

    }
    public static string GetGrade(int percentage)
    {
        // If the data is invalid, then throw new exception

        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException("Percentage must be between 0 and 100.");
        }

        string grade = percentage >= 65 ? (percentage >= 85 ? "You passed with distinction!" : "You passed.") : "You failed.";
        return grade;
    }
    #endregion

    #region SWITCH STATEMENTS
    public static string Priority(int level)
    {

        if (!int.TryParse(level.ToString(), out int result))
        {
            throw new ArgumentException("Input parameter must be an integer.");
        }


        string priority = "Code ";

        switch (level)
        {
            case 3:
                priority = priority + "Red";
                break;
            case 2:
            case 1:
                priority = priority + "Amber";
                break;
            case 0:
                priority = priority + "Green";
                break;
            default:
                priority = "Error";
                break;
        }
        return priority;
    }

    public static string DrivingLaw(int age)
    {
        string law = "";

        switch (age)
        {
            case < 17:
                law = "Cannot legally drive.";
                break;
            case < 23:
                law = "Can legally drive but can't hire a car.";
                break;
            default:
                law = "Can legally drive and rent a car.";
                break;
        }
        return law;
    }

    #endregion

    #region ITERATIONS (LOOPS)

    public static void Iterations()
    {
        int[] myArray = new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55};
        int sumOfMyArrayNumbers = myArray[0];

        // Use a for loop to iterate over an explicit range of indices within a collection
        // (e.g., a string, list, or array)
        for (int i = 0; i < myArray.Length; i++)
        {
            sumOfMyArrayNumbers += myArray[i];
        }

        // Use a foreach loop to iterate over an entire collection.
        // Note!!! foreach loops can't be used to update the data in a collection.
        foreach (var item in myArray)
        {

        }

        // To keep looping until some condition changes i.e., the body of the loop
        // MUST change the condition, otherwise an infinite loop will occur.
        while (true)
        {

        }

        // A do-while loop is basically a while loop that runs at least once.
        do
        {

        } while (true);
    }

    #endregion

}