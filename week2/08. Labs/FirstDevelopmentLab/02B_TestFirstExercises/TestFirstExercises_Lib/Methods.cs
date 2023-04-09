using System;
using System.Collections.Generic;

namespace TestFirstExercises;

public class Methods
{
    // implement this method so that it returns true if x is greater than or equal to y
    public static bool GreaterEqual(int x, int y)
    {
        return x >= y;
    }

    // Implement this method so that it take an int as an input,
    // squares it, adds 101, divides the result by 7, then subtracts 4.  
    // Return a double rounded to 3 decimal places.
    public static double BODMAS(int inputNumber)
    {
        double result = ((inputNumber * inputNumber) + 101) / 7.0 - 4;
        return Math.Round(result, 3);
    }

    // implement this method so that it returns true if num is even, otherwise false
    public static bool EvenOdd(int num)
    {
        return num % 2 == 0;
    }

    // implement this method so that it returns 
    // the sum of all numbers between 1 and n inclusive 
    // that are divisible by either 2 or 5
    public static int SumEvenFive(int max)
    {
        int sum = 0;
        for (int i = 1; i <= max; i++)
        {
            if (i % 2 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        return sum;
    }

    // implement this method so it returns true if input is "password"
    // regardless of case
    public static bool CheckInput(string input)
    {
        return input.ToLower() == "password";
    }

    // implement this method so it returns the sum
    // of all the numbers in the list
    public static int SumList(List<int> list)
    {
        int sum = 0;
        foreach (int num in list)
        {
            sum += num;
        }
        return sum;
    }
}
