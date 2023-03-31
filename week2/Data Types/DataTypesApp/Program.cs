using System;
using System.Text;

namespace DataTypesApp
{
    public class Program
    {
        static void Main()
        {
            #region Numerical Data Types
            //// statically typed = a variable is declared with a known type
            //int n = 10;
            //var x = n;

            //// type safe = the type of variable is "safe", it cannot be changed
            //// n = "string";

            //// memory safe
            //// - have a garbage collector
            //// - cannot directly access memory like in C++
            //// - types have a fixed memory size, and they cannot be changed, so we always know how much memory they'll need

            //n = -999;
            //// data literal - just a value
            //float f = 9f;
            //Console.WriteLine(f);

            //float sum = 0;

            //// precision

            //for (int i = 0; i < 1_000_000; i++)
            //{
            //    sum += 2 / 5f; // 0.4
            //}

            //Console.WriteLine(sum);

            //// Safe type conversions

            //sum = n;



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

            #region Strings

            // string manipulation & the string builder

            var myString = " C# list fundamentals ";
            Console.WriteLine(StringExercise(myString));

            // string interpolation
            int cheeseStock = 101;
            Console.WriteLine("I have " + cheeseStock + " units of " + cheese + " in stock."); // string concatenation
            Console.WriteLine($"I have {cheeseStock / 100} units of {StringExercise(cheese)} in stock."); // string interpolation
            string aLiteralString = @"C:\Users\phili\Documents\myStuff";

            Console.WriteLine($"Log to the base 2 of 7 is {Math.Log(7, 2):0.#####}");
            Console.WriteLine($"That would be {2 / 7d:C}");
            #endregion

            #region Arrays

            // 1 dimensional arrays
            // 12 23 34 45 56

            int[] myIntArray = { 12, 23, 34, 45, 56 };
            int[] my

            // Multi-dimensional arrays (matrices)

            int[,] my2DArray =
            {
                { 1, 2, 3 },
                { 3, 4, 5 },
                { 6, 7, 8 }
            };

            int[,] my2DArray2 = new int[3, 3];

            Console.WriteLine(my2DArray[0, 0]);

            foreach(var item in my2DArray)
            {
                Console.Write(item + ", ");
            }


            // Jagged Arrays
            // So-called because it is basically an array of arrays

            int[][] myJaggedArray =
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };

            Console.WriteLine(myJaggedArray[2][1]);


            #endregion

        }





        private static string StringExercise(string myString);

        {
            var modded = myString.Trim().ToUpper().Replace('T', '*').Replace('L', '*');
            int indexOfN = modded.IndexOf('N');
            return modded.Remove(indexOfN + 1);

        }

        private static string StringBuilderExercise(string myString)
        {
            string modded = myString.Trim().ToUpper();
            int indexOfN = modded.IndexOf('N');

            var sb = new StringBuilder(modded);

            sb.Replace('T', '*').Replace('L', '*').Remove(indexOfN + 1, sb.Length - 1 - indexOfN);


        }

            

           











            Console.WriteLine(StringExercise(replacement2));

        }
    }
}