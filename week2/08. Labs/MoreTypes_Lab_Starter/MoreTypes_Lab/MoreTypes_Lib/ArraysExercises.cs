using System;
using System.Collections.Generic;

namespace MoreTypes_Lib
{
    public class ArraysExercises
    {
        // returns a 1D array containing the contents of a given List
        public static string[] Make1DArray(List<string> contents)
        {
            return contents.ToArray();  // casts the list to an array
        }

        // returns a 3D array containing the contents of a given List
        public static string[,,] Make3DArray(int length1, int length2, int length3, List<string> contents)
        {
            
            if (length1 * length2 * length3 != contents.Count)
            {
                throw new ArgumentException("Number of elements in list must match array size");
            }

            string[,,] result = new string[length1, length2, length3];

            int i = 0;
            for (int x = 0; x < length1; x++)
            {
                for (int y = 0; y < length2; y++)
                {
                    for (int z = 0; z < length3; z++)
                    {
                        result[x, y, z] = contents[i];
                        i++;
                    }
                }
            }

            return result;
        }

        // returns a jagged array containing the contents of a given List
        public static string[][] MakeJagged2DArray(int countRow1, int countRow2, List<string> contents)
        {
            string[][] arr = new string[countRow1][];
            arr[0] = new string[countRow1];
            arr[1] = new string[countRow2];

            if (countRow1 + countRow2 != contents.Count)
            {
                throw new ArgumentException("Number of elements in list must match array size");
            }

            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.length; j++)
                {

                }
            }
        }
    }
}
