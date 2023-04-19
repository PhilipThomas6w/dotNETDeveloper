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

        // A program that takes in a score from a user input and prints a corresponding grade to the console.

        string grade = "";
        bool validInput = false;
        int percentageScore;
        do
        {
            try
            {
                Console.WriteLine("Enter your percentage score: ");
                string input = Console.ReadLine();

                // Check if input is an empty string
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("Invalid Input. Please enter a value between 0 and 100. ");
                    validInput = false;
                }
                // Parse the input as an integer
                else if (int.TryParse(input, out percentageScore))
                {
                    grade = GetGrade(percentageScore);
                    validInput = true;
                }
                else
                {
                    Console.Write("Invalid input. Please enter a value between 0 and 100. ");
                    validInput = false;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Write("Invalid input. Please enter a value between 0 and 100. ");
                validInput = false;
            }

        } while (!validInput);  // while validInput is false, iterate through the instructions in the try-catch blocks.

        Console.WriteLine(grade);

        #endregion
    }

    public static string GetGrade(int scoreAsPercentage)
    {
        // If the data is invalid, then throw new exception

        if (scoreAsPercentage < 0 || scoreAsPercentage > 100) throw new ArgumentOutOfRangeException("Percentage must be between 0 and 100.");

        string grade = scoreAsPercentage >= 65 ? (scoreAsPercentage >= 85 ? "You passed with distinction!" : "You passed.") : "You failed.";
        return grade;
    }


}