using System;

namespace DataTypes_Lib
{
    public static class IntegerCalc
    {
        public static int Add(int num1, int num2)
        {
            if ((long)num1 + num2 > int.MaxValue)   // Note, we need to use a numerical data type that can store a value greater than int.MaxValue i.e., a long.
            {
                throw new OverflowException();
            }
            if ((long)num1 + num2 < int.MinValue)   
            {
                throw new OverflowException();
            }
            return num1 + num2;
        }

        public static int Subtract(int num1, int num2) 
        {
            if((long)num1 - num2 > int.MaxValue)    // args will be (int.MaxValue, -3); subtracting -3 will cancel out and give +3, exceeding int.MaxValue.
            {
                throw new OverflowException();
            }
            if ((long)num1 - num2 < int.MinValue)   // args will be (int.MinValue, 3); subtracting 3 will exceeding int.MinValue.
            {
                throw new OverflowException();
            }
            return num1 - num2;
        }

        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public static int Divide(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException("Can't divide by zero");
            }    
            return num1 / num2;
        }

        public static int Modulus(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException("Can't modulo by zero");
            }
            return num1 % num2;
        }
    }
}
