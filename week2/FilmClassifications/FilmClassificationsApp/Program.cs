namespace FilmClassificationsApp;

public class Program
{
    public static void Main()
    {
        bool validAge = false;
        do
        {
            try
            {
                Console.WriteLine("How old are you?");
                int age;
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    throw new FormatException("FormatException: Please enter a whole number between 0 and 130.");
                }
                Console.WriteLine(AvailableClassifications(age));
                validAge = true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ArgumentOutOfRangeException: Enter a whole number between 0 and 130.");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        } while (!validAge);
    }


    public static string AvailableClassifications(int ageOfViewer)
    {
        if (ageOfViewer < 0 || ageOfViewer > 130) throw new ArgumentOutOfRangeException();
        
        int number;
        if (!int.TryParse(ageOfViewer.ToString(), out number))
        {
            throw new FormatException("The input age is not a valid integer value.");
        }


        string result;
        if (ageOfViewer < 12)
        {
            result = "U, PG & 12 films are available.";
        }
        else if (ageOfViewer < 15)
        {
            result = "U, PG, 12 & 15 films are available.";
        }
        else
        {
            result = "All films are available.";
        }
        return result;
    }
}

