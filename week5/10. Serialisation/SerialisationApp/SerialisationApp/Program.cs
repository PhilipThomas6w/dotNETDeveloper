namespace SerializationApp;

public class Program
{
    static void Main()
    {
        Trainee vlad = new() { FirstName = "Vlad", LastName = "Stoyanov", SpartaNo = 7 };

        ISerializer serializer = new WrappedXmlSerializer();

        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Trainees";

        serializer.SerializeObject<Trainee>(filePath + "/vlad.xml", vlad);

        var trainee = serializer.DeserializeObject<Trainee>(filePath + "/vlad.xml");
        Console.WriteLine(trainee);
    }
}