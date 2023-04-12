using System;
using System.Collections.Generic;

namespace Collections_Lib
{
    public class CollectionsExercises
    {

        /* removes and returns the next num entries in the queue, as a comma separated string */
        public static string NextInQueue(int num, Queue<string> queue)
        {
            throw new NotImplementedException();
        }

        /* uses a Stack to create and return array of ints in reverse order to the one supplied */
        public static int[] Reverse(int[] original)
        {
            throw new NotImplementedException();
        }
        // using a Dictionary, counts and returns (as a string) the occurence of the digits 0-9 in the given string
        public static string CountDigits(string input)
        {
            Dictionary<char, int> count = new() { };

            foreach (char c in input) 
            {
                if (char.IsDigit(c))
                {
                    if (count.ContainsKey(c))
                    {
                        count[c]++;
                    }
                    else
                    {
                        count[c] = 1;
                    }
                }
            }

            string result = "";
            foreach (KeyValuePair<char, int> pair in count)
            {
                result += pair.Key + ":" + pair.Value + " ";
            }

            return result.TrimEnd();
        }
    }
}
