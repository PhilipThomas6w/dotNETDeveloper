namespace FizzBuzzApp
{
    public class Program
    {
        
        static void Main()
        {

        }

        public static string FizzBuzz(int number)
        {
            string fizzBuzzString = "";

            for (int i = 1; i <= number; i++)
            {
                if (i == 0)
                    return "";
                else if (i % 3 == 0 && i % 5 == 0)
                    fizzBuzzString += "FizzBuzz";
                else if (i % 3 == 0)
                    fizzBuzzString += "Fizz ";
                else if (i % 5 == 0)
                    fizzBuzzString += "Buzz ";
                else
                    fizzBuzzString += i + " ";
            }

            return fizzBuzzString.Trim();
           
        }
    }
}