namespace ExceptionsApp
{
    public class Program
    {
        static void Main()
        {
            var text = File.ReadAllText("C://Users//phili//Documents/mysupersecretpassword.txt");
            Console.WriteLine(text);
        }
    }
}