namespace UnitTestLessonApp
{
    public class Program
    {
        static void Main()
        {
            int timeOfDay = DateTime.Now.Hour;
            Console.WriteLine(GetMessage(timeOfDay));
        }

        public static string GetMessage(int timeOfDay)
        {
            if (timeOfDay < 5)
            {
                return "Good evening!";
            }
            else if (timeOfDay < 12)
            {
                return "Good morning!";
            }
            else if (timeOfDay < 18)
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

