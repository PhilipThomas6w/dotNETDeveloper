using System;
using System.Text;

namespace DataTypesApp;

public enum Suit
{
    HEARTS = 10, // const int HEARTS = 10
    CLUBS = 15, // const int CLUBS = 15
    DIAMONDS = 2, // const int DIAMONdS = 2
    SPADES = 99 // const int SPADES = 99
}
public class Program
{
    static void Main()
    {
        #region NUMERICAL DATA TYPES

        // C# is:
        //// statically typed = a variable is declared with a known type e.g.,
        //int n = 10;
        //var x = n;

        //// type safe = the type of variable is "safe", it cannot be changed e.g., 
        //// n = "string";

        //// memory safe
        //// - has a garbage collector
        //// - cannot directly access memory like in C++
        //// - types have a fixed memory size, and they cannot be changed, so we always know how much memory they'll need

        //n = -999;
        //// literal - just a value
        //float f = 9f;
        //Console.WriteLine(f);

        //float sum = 0;

        //// precision

        //for (int i = 0; i < 1_000_000; i++)
        //{
        //    sum += 3 / 8f; // 0.375
        //}

        //Console.WriteLine(sum);

        //// Safe type conversions

        //sum = 10; // int into float
        //long l = n; // int into long
        //uint population = 68_000_000;
        //l = population;
        // n = population;  uint into is not OK

        //// overflow and underflow

        //checked
        //{
        //    byte cows = 255;
        //    cows++; // overflow error

        //    Console.WriteLine($"I have {cows} cows");
        //}

        //// Unsafe type conversions

        //int students = 1600;
        //byte bStudents = Convert.ToByte(students);
        //// bStudents = Byte.Parse(students);

        //// Casting

        //bStudents = (byte)students;

        //double a = 3.14159265359;
        //float b = (float)x;
        //Console.WriteLine(a);
        //Console.WriteLine(b);

        //int bankBalance = 2;
        //uint bankBalanceUInt;
        //bankBalance -= 9000;
        //bankBalanceUInt = (uint)bankBalance;
        //Console.WriteLine("Bank Balance is: ");
        //Console.WriteLine

        #endregion

        #region STRINGS

        // string manipulation & the string builder

        //char c = 'A';
        //string cheese = "Cheddar";
        ////Console.WriteLine(cheese);
        ////Console.WriteLine(cheese[2]); // e
        ////Console.WriteLine((int)c);  // 65

        //var myString = " C# list fundamentals ";
        //Console.WriteLine(StringExercise(myString));
        //Console.WriteLine(StringBuilderExercise(myString));

        //// string interpolation
        //int cheeseStock = 101;
        //Console.WriteLine("I have " + cheeseStock + " units of " + cheese + " in stock."); // string concatenation
        //Console.WriteLine($"I have {cheeseStock / 100} units of {StringExercise(cheese)} in stock."); // string interpolation
        //string aLiteralString = @"C:\Users\phili\Documents\myStuff";

        //Console.WriteLine($"Log to the base 2 of 7 is {Math.Log(7, 2):0.#####}");
        //Console.WriteLine($"That would be {2 / 7d:C}");
        #endregion

        #region ARRAYS

        //// 1 dimensional arrays
        //// 12 23 34 45 56

        //int[] myIntArray = { 12, 23, 34, 45, 56 };
        //int[] my

        //// Multi-dimensional arrays

        //int[,] my2DArray =
        //{
        //    { 1, 2, 3 },
        //    { 3, 4, 5 },
        //    { 6, 7, 8 }
        //};

        //int[,] my2DArray2 = new int[3, 3];

        //Console.WriteLine(my2DArray[0, 0]);

        //foreach(var item in my2DArray)
        //{
        //    Console.Write(item + ", ");
        //}


        // Jagged Arrays
        // So-called because it is basically an array of arrays

        int[][] myJaggedArray =
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
        };


        int[][] myJaggedArray2 = new int[2][];
        myJaggedArray2[0] = new int[3];
        myJaggedArray2[1] = new int[2];

        myJaggedArray2[0][1] = 99;

        Console.WriteLine(myJaggedArray2[1][1]);

        // To iterate through a jagged array...

        foreach (var innerArray in myJaggedArray)
        {
            foreach (var value in innerArray)
            {
                Console.WriteLine(value);
            }
        }


        #endregion

        Console.WriteLine();    // Creating line space for readability

        #region DATETIME

        Console.WriteLine(DateTime.Now);

        #endregion

        #region ENUMS - ENUMERATED TYPES

        // An enum is a fixed collection of constants

        const int maxClassSize = 16;

        Suit mySuit = Suit.CLUBS;
        mySuit = Suit.HEARTS;

        mySuit = (Suit)99;
        int spadesValue = (int)Suit.SPADES;

        string userInput = Console.ReadLine();
        mySuit = (Suit)Enum.Parse(typeof(Suit), userInput);

        switch (mySuit)
        {
            case (Suit.HEARTS):
                Console.WriteLine("It's a Heart");
                break;
            case (Suit.CLUBS):
                Console.WriteLine("It's a Club");
                break;
            case (Suit.SPADES):
                Console.WriteLine("It's a Spade");
                break;
            case (Suit.DIAMONDS):
                Console.WriteLine("It's a Diamond");
                break;
        }


        #endregion

    }





    private static string StringExercise(string myString)
    {
        string modifiedString = myString.Trim().ToUpper().Replace('T', '*').Replace('L', '*');
        int indexOfN = modifiedString.IndexOf('N');
        return modifiedString.Remove(indexOfN + 1);
    }

    private static string StringBuilderExercise(string myString)
    {
        string modifiedString = myString.Trim().ToUpper();
        int indexOfN = modifiedString.IndexOf('N');
        StringBuilder sb = new StringBuilder(modifiedString);
        sb.Replace('T', '*').Replace('L', '*').Remove(indexOfN + 1, sb.Length - 1 - indexOfN);
        return sb.ToString();

    }
}