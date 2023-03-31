using System;

namespace MoreTypes_Lib
{
    public class StringExercises
    {
        // manipulates and returns a string - see the unit test for requirements
        public static string ManipulateString(string input, int num)
        {
            var result = input.Trim().ToUpper();
            for (int i = 0; i < num; i++)
            {
                result += i;
            }
            return result;
        }

        // returns a formatted address string given its components
        public static string Address(int number, string street, string city, string postcode)
        {
            //string numberAsString = number.ToString();
            var result = $"{number} {street}, {city} {postcode}.";
            return result;
        }
        // returns a string representing a test score, written as percentage to 1 decimal place
        public static string Scorer(int score, int outOf)
        {
            double percentage = (double)score / outOf * 100;
            return $"You got {score} out of {outOf}: {percentage:F1}%";
        }

        // returns the double represented by the string, or -999 if conversion is not possible
        public static double ParseNum(string numString)
        {
            double result;
            if (Double.TryParse(numString, out result))
            {
                return result;
            }
            else
            {
                return -999;
            }
        }

        // Returns the a string containing the count of As, Bs, Cs and Ds in the parameter string
        // all other letters are ignored
        public static string CountLetters(string input)
        {
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int countD = 0;
            foreach (char c in input)
            {
                switch (c)
                {
                    case 'A':
                        countA++;
                        break;
                    case 'B':
                        countB++;
                        break;
                    case 'C':
                        countC++;
                        break;
                    case 'D':
                        countD++;
                        break;
                }
            }
            return $"A:{countA} B:{countB} C:{countC} D:{countD}";
        }
    }
}
