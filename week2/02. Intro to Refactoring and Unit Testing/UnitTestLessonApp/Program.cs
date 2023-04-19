namespace UnitTestLessonApp;

public class Program
{
    static void Main()
    {
        int inputFromDateTimeStruct = DateTime.Now.Hour;
        Console.WriteLine(GetMessage(inputFromDateTimeStruct));
    }

    public static string GetMessage(int timeOfDay)
    {
        if (timeOfDay <0 || timeOfDay > 24)
        {
            throw new ArgumentOutOfRangeException();
        }

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
        //else
        //{
        //    return "Good evening!";
        //}
    }
}

