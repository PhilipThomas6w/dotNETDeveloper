using System;

namespace DataTypes_Lib
{
    public class TypeConversion
    {
        public static short UIntToShort(uint num)
        {
            if (num > short.MaxValue)
            {
                throw new OverflowException();
            }
            
            return (short)num;
        }

        public static long FloatToLong(float num)
        {
            return (long)Math.Round(num);  // Not sure why Math.Floor didn't work here...
        }
    }
}
