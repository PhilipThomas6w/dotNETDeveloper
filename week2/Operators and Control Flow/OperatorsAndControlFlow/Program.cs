using System.Globalization;
using Loops;

namespace OperatorsAndControlFlow;

internal class Program
{
    static void Main()
    {
        #region Operators

        // pre-increment and post-increment operators
        int x = 5;
        int y = 5;

        int w = x++; // w = 5, x = 6
        int z = ++y; // z = 6, y = 6

        // var & integer division
        long l = 10_000_000_000;
        var n = 10;
        var s = "Hello";

        var pizzaSlices = 5;
        var pizzaEaters = 2;

        // How many pizzaSlices does each pizzaEater get?

        var slicesPerEater = pizzaSlices / pizzaEaters;

        Console.WriteLine($"Each person can have {slicesPerEater} slices of pizza");

        // slicesPerEater above returns 2, not 2.5. Why?
        // Because the result of the division is an integer, not a double. 
        // To get a double, we need to cast one of the operands to a double.

        var slicesPerEater2 = (double)pizzaSlices / pizzaEaters;

        Console.WriteLine($"Sorry! I meant that each person can have {slicesPerEater2} slices of pizza");

        // ###Modulus operator###
        // The modulus operator returns the remainder of a division operation.

        // Let's assume that each pizzaEater only eats 2 slices of pizza each. How many are left over?

        var slicesLeftOver = pizzaSlices % pizzaEaters;

        Console.WriteLine($"There are {slicesLeftOver} slices left over");

        // ###Assignment operators###
        // Assignment operators are used to assign a value to a variable.

        x = 5;
        x = x + 10; // x is now 15
        x += 10; // x is now 25. i.e., x = x + 10 is the same as x += 10

        // ###Conditional expressions & logical operators###
        // Conditional expressions are used to evaluate a condition and return a value based on the result of the condition.

        // bool isComfortable = portion >= 2 & leftOvers > 0 | myHalf < pizzaEaters;

        // ###Short-circuit operators###
        // Short-circuit operators are used to control the flow of logical expressions, by evaluating only the minimum number of operands required to determine the result of the expression.

        // There are two short-circuit operators in C#: the logical AND operator && and the logical OR operator ||.

        // The logical AND operator && evaluates the second operand only if the first operand evaluates to true.

        int x = 5;
        int y = 10;








        Console.WriteLine("Input a number of days: ");
        int numberOfDays = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(GetWeeksAndDays(numberOfDays));

        #endregion

        #region Control Flow

        // ternary operator ? :
        // The ternary operator is a conditional operator that evaluates a condition and returns a value based on the result of the condition.

        int grade = 71;
        string result = "";

        // The ternary operator is a shortcut for the following if/else statement:

        result = grade >= 65 ? "Pass" : "Fail";

        // The above is equivalent to:

        if (grade >= 65) result = "Pass";
        else result = "Fail";

        // ###Loops###

        // for
        // Loops a specified number of times; the body of the loop must change the loop variable

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }

        // foreach 
        // Loops through a collection of items; item is readonly

        foreach (var item in collection)
        {

        }


        // while
        // Loops until a condition is negated; the body of the loop must change the condition

        while (true)
        {

        }



        // do-while
        // A while loop that executes at least once

        do
        {
        } while (true);

        // implement above, to return the number of weeks and days

        #endregion

        List<int> nums = new List<int> { 10, 6, 22, -17, 3 };

        Console.WriteLine("Highest number using a for loop: " + LoopExamples.HighestForLoop(nums));
        Console.WriteLine("Highest number using a foreach loop: " + LoopExamples.HighestForeachLoop(nums));
        Console.WriteLine("Highest number using a while loop: " + LoopExamples.HighestWhileLoop(nums));
        Console.WriteLine("Highest number using a dowhile loop: " + LoopExamples.HighestDoWhileLoop(nums));


    }

    public static string Priority(int level)
    {
        string priority = "Code ";
        switch (level)
        {
            case 3: priority = priority + "Red"; break;
            case 2: case 1: priority = priority + "Amber"; break;
            case 0: priority = priority + "Green"; break;
            default: priority = "Error"; break;
        }
        return priority;
    }

    public static string GetGrade(int grade)
    {
        return grade >= 65 ? "Pass" : "Fail";
    }

    private static string GetWeeksAndDays(int days)
    {
        int numberOfWeeks = days / 7;
        int numberOfRemainingDays = days % 7;

        return $"{days} is {numberOfWeeks} weeks and {numberOfRemainingDays} days";

    }

    
    
}