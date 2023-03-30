using System.Linq.Expressions;

namespace ExceptionsApp;

public class Program

    static void Main() 
    {

        // program that takes in user text input, a score, and tells them their grade

        Console.WriteLine("Enter your score: ");
        string inputScore = Console.ReadLine();

        int actualScore = Convert.ToInt32(inputScore);

        while (actualScore < 0 || actualScore > 100)
        { 
            Console.WriteLine("Score must be between 0 and 100, please try again");
            inputScore = Console.ReadLine();
            actualScore = Convert.ToInt32(inputScore);
        }
        Console.WriteLine(GetGrade(actualScore));

    }

    public static string GetGrade(int grade);
    {
        if (grade < 0 || grade > 100)
        return grade();


    }
    





        // handle exceptions

        try
        {
            var text = File.ReadAllText("C://Users//phili//Documents/mysupersecretpassword.txt");
            Console.WriteLine(text);
        }

        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found");
            Console.WriteLine (EndOfStreamException.Message);
        }

        catch (ArgumentException e)
        {
            Console.WriteLine("An invalid argument was found");
            Console.WriteLine(e.Message);
        }

        catch (Exception e)
        { 
            Console.WriteLine("There was an error :(");
            Console.WriteLine(e.Message);
        }

        finally
        { 
            Console.WriteLine("I am always run");
        }

    }