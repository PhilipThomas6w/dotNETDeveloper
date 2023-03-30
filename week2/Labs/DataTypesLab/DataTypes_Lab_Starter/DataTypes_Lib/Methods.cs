using System;

namespace DataTypes_Lib
{
    public static class Methods
    {
        // write a method to return the product of all numbers from 1 to n inclusive
        public static int Factorial(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("n must be a positive integer!");
            }

            int product = 1;

            for (int i = 1; i <= n; i++)
            {
                product *= i;
            }

            return product;
        }

        public static float Mult(float num1, float num2)
        {
            float result = num1 * num2;
            return (float)Math.Round(result, 5);
        }
    }
}
