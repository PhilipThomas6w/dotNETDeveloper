namespace FourPillarsApp;

public class Program
{
    static void Main()
    {
        // instantiation
        Person andrew = new Person("Andrew", "Ma"); // Here, <new> is the constructor we use to instantiate an object, <andrew>, belonging to the class <Person>
        andrew.Age = 22;                            // To assign a value to any member of a class, we use dot-notation.

        /*andrew._firstName = "Andy";*/             // We can't update the _firstName field because it's protection level is set to private i.e., it has been encapsulated within the Person class.

        Console.WriteLine(andrew.GetFullName());    // You have to call the method on an object, since it's objects that actually store data. You can't call them on a class itself.

        var talal = new Person("Talal", "Hassan", 22);
        Console.WriteLine(talal.GetFullName("Mr"));



    }
}