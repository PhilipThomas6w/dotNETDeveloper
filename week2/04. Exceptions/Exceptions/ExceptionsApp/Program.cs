namespace ExceptionsApp;

public class Program
{
    static void Main()
    {
        #region HANDLING EXCEPTIONS

        //try
        //{
        //    //int zero = 0;
        //    //int n = 10 / zero;  // This will throw an exception, and will be caught by the catch (Exception e) catch clause below, but a third party wouldn't know what had actually caused the error - this is why using general catch clauses is bad practice.

        //    var aRealFile = File.ReadAllText("C:\\Users\\phili\\Documents\\aRealFile.txt");
        //    Console.WriteLine(aRealFile);

        //    var aNonExistentFile = File.ReadAllText("C:\\Users\\phili\\Documents\\aNonExistentFile.txt");
        //    Console.WriteLine(aNonExistentFile);
        //}
        //catch (FileNotFoundException e)
        //{
        //    Console.WriteLine("File not found.");
        //    Console.WriteLine(e.Message);
        //}
        //catch (ArgumentException e)
        //{
        //    Console.WriteLine("An invalid Argument was found.");
        //    Console.WriteLine(e.Message);
        //}
        //catch (Exception e) //The catch (Exception e) catch clause will catch any exception that hasn't already been caught by the specific catch clauses above i.e., any except FileNotFoundExceptions and ArgumentExceptions.
        //{
        //    Console.WriteLine("There was an error.");
        //}
        //catch   // This is another general catch clause. It will catch any exception. However, it is redundant in this case because all errors not already caught by the specific clauses will be caught by the catch (Exception e) catch clause above.
        //{
        //    Console.WriteLine("There was an error.");
        //}
        //finally
        //{
        //    Console.WriteLine("I am always run.");
        //}

        //// General catch clauses are viewed as "cop-outs" (Peter Bellaby), because they don't tell you much if caught; they just stop your program from crashing.
        ///
        #endregion

        #region DEMO: try-catch block

        // A program that takes in user text input, a score, and tells them their grade

        //Console.WriteLine("Enter your percentage mark: ");
        //int percentageAsInt = Int32.Parse(Console.ReadLine());

        string grade = "";
        bool validInput = false;
        do
        {
            try
            {
                Console.WriteLine("Enter your percentage mark: ");
                int percentageAsInt = Int32.Parse(Console.ReadLine()); 
                grade = GetGrade(percentageAsInt);
                validInput = true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Percentage must be between 0 and 100.");
                validInput = false;
            }
        } while (!validInput);

        Console.WriteLine(grade);
       


        #endregion

    }

    public static string GetGrade(int percentage)
    {
        // If the data is invalid, then throw new exception

        if (percentage < 0 || percentage > 100) throw new ArgumentOutOfRangeException("Percentage must be between 0 and 100.");

        string grade = percentage >= 65 ? (percentage >= 85 ? "You passed with distinction!" : "You passed.") : "You failed.";
        return grade;
    }


}