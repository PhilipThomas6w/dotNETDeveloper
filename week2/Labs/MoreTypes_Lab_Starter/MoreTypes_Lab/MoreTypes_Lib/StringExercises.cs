using System;

namespace MoreTypes_Lib
{
    public class StringExercises
    {
        // manipulates and returns a string - see the unit test for requirements
        public static string ManipulateString(string input, int num)
        {
            var result = input.Trim().ToUpper();    // trim any leading or trailing whitespace, convert to uppercase
            for (int i = 0; i < num; i++)           // start at i = 0, iterate while i is less than num, increment i
            {
                result += i;                        // append i to result
            }
            return result;
        }

        // returns a formatted address string given its components
        public static string Address(int number, string street, string city, string postcode)
        {
            //string numberAsString = number.ToString();
            var result = $"{number} {street}, {city} {postcode}."; // simple example of string interpolation
            return result;
        }
        // returns a string representing a test score, written as percentage to 1 decimal place
        public static string Scorer(int score, int outOf)
        {
            double percentage = (double)score / outOf * 100;    // cast score to a double, divide by outOf and multiply by 100 to get a %, store result in a double
            return $"You got {score} out of {outOf}: {percentage:F1}%";
        }

        // returns the double represented by the string, or -999 if conversion is not possible
        public static double ParseNum(string numString)
        {
            double result;
            if (Double.TryParse(numString, out result))     // try to parse the string to a double
            {
                return result;                              // if the string can be parsed, return the parsed string
            }
            else
            {
                return -999;                                // else if it can't be parsed, return -999
            }
        }

        // Returns the a string containing the count of As, Bs, Cs and Ds in the parameter string
        // all other letters are ignored
        // this is very similar to the common DNA nucleotide coding test question; initialise each letter to 0 and then use a switch statement to iterate through the string input
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
