namespace UnitTestLessonApp
{
    internal class Program
    {
        static void Main()
        {
            int inputTimeOfDay = Int32.Parse(Console.ReadLine());

            Console.WriteLine(GetMessage(inputTimeOfDay));

        }

        private static string GetMessage(int timeOfDay)
        {
            if (timeOfDay >= 5 && timeOfDay < 11)
            {
                return "Good morning!";
            }
            else if (timeOfDay >= 12 && timeOfDay < 18)
            {
                return "Good afternoon!";
            }
            else
            {
                return "Good evening!";
            }
        }
    }
}
