using System.Diagnostics.Metrics;
using System;

namespace FourPillarsApp;

public class Program
{
    static void Main()
    {

        #region ABSTRACTION & ENCAPSULATION
        // Instantiation

        Person andrew = new Person("Andrew", "Ma");
        /*andrew.Age = 22;*/ // This no longer compiles because set Age is marked as private. To get it to compile, remove the private access modifier.

        Console.WriteLine(andrew.GetFullName()); // You have to call a method from the OBJECT (i.e., not the class) it is a member of

        var talal = new Person("Talal", "Hassan", 22);

        Console.WriteLine(talal.GetFullName("Mr"));

        // Object initialisers
        var patrick = new Person("Patrick", "Ardagh") { Age = 24, Height = 300 };
        //int[] array = new int[] { 1, 2, 3 };  // Notice the similarity in syntax with arrays and lists
        //List<int> myList = new List<int> { 4, 5, 6 };

        Park hydePark = new Park() { Location = "London", Name = "Hyde Park", ParkManager = new Person("Dave", "Davidson", 34), Roundabouts = 4, Swings = 12, Trees = 123 };
        Console.WriteLine($"{hydePark.ParkManager.GetFullName()} is {hydePark.ParkManager.Age} years old and {hydePark.ParkManager.Height} cm tall.");

        Point3D point = new Point3D(1, 2);
        Point3D empty;

        #endregion

        #region INHERITANCE

        Hunter danielle = new Hunter("Danielle", "Massey", "Kodak");

        Console.WriteLine(danielle.Shoot());
        Console.WriteLine(danielle.GetFullName());  // Note that all of the members of the base class are available.

        Console.WriteLine(danielle.ToString());




        #endregion


    }
}