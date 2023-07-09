using System.Diagnostics.Metrics;
using System;

namespace FourPillarsApp;

public class Program
{
    static void Main()
    {
        #region FIELDS AND ACCESSORS

        Console.WriteLine("FIELDS & ACCESSORS DEMO");
        
        var oldPerson = new Person();
        var secretKey = oldPerson.getSecret("potatoes");
        Console.WriteLine(secretKey);

        #endregion

        #region ABSTRACTION & ENCAPSULATION
        // Working with classes, instantiating

        Console.WriteLine("\nABSTRACTION & ENCAPSULATION DEMO\n");
        
        Person andrew = new Person("Andrew", "Ma"); // Instantiating an instance of the Person class
        andrew.Age = 22;    // setting the value of andrew's _age to 22.

        Console.WriteLine(andrew.GetFullName()); // You have to call a method on the OBJECT (i.e., not the class)
        Console.WriteLine($"{andrew.GetFullName()} is {andrew.Age} years old.");


        var talal = new Person("Talal", "Hassan", 22);

        Console.WriteLine(talal.GetFullName("Mr"));

        // Object initializers
        var patrick = new Person("Patrick", "Ardagh") { Age = 24, Height = 300 };

        Console.WriteLine($"Patrick is {patrick.Age} years old and {patrick.Height} cm tall!");

        // ~~ The syntax we used in the object initializer for Patrick has same effect as what we do for Matt, below.

        var matthew = new Person("Matthew", "Handley");
        matthew.Age = 29;
        matthew.Height = 78;

        Console.WriteLine(($"{matthew.GetFullName()} is {matthew.Age} years old and {matthew.Height} cm tall."));


        Park hydePark = new Park() 
            { 
                Location = "London",
                Name = "Hyde Park", 
                ParkManager = new Person("Dave", "Davidson", 34),
                Roundabouts = 4, 
                Swings = 12, 
                Trees = 123
            };
        
        Console.WriteLine($"{hydePark.ParkManager.GetFullName()} is {hydePark.ParkManager.Age} years old and {hydePark.ParkManager.Height} cm tall.");

        Point3D point = new Point3D(1, 2);

        Console.WriteLine($"The point is {point.distanceFromOrigin()} units from the origin.");

        #endregion

        #region INHERITANCE

        Console.WriteLine("\nINHERITANCE DEMO\n");

        var danielle = new Hunter("Danielle", "Massey", "Kodak");

        Console.WriteLine(danielle.Shoot());
        Console.WriteLine(danielle.GetFullName());  // Note that all of the members of the base class are available.

        Console.WriteLine(danielle.ToString());

        var person = new Person();
        Console.WriteLine(person.ToString());

        var idris = new Hunter("Ahmed", "Idris", "Canon");
        Console.WriteLine($"Idris is a {idris.GetType()}");


        #endregion


        #region Polymorphism

        Console.WriteLine("\nPOLYMORPHISM DEMO\n");

        var myDog = new Dog();
        var myCat = new Cat();
        var myBird = new Bird();

        Console.WriteLine($"The dog says {myDog.Speak()}");
        Console.WriteLine($"The cat says {myCat.Speak()}");
        Console.WriteLine($"The bird says {myBird.Speak()}");

        Console.WriteLine();

        List<Animal> animals = new() { myDog, myCat, myBird };

        foreach (var animal in animals)
        {
            Console.WriteLine($"The {animal} says {animal.Speak()}");
        }

        Console.WriteLine();    // linespace

        Animal? myAnimal;

        Console.WriteLine("Please choose an animal from cat, dog, or bird.\n");

        string input = Console.ReadLine();


        switch (input.ToLower())
        {
            case "dog":
                myAnimal = new Dog();
                break;
            case "cat":
                myAnimal = new Cat();
                break;
            case "bird":
                myAnimal = new Bird();
                break;
            default:
                Console.WriteLine("Not an animal...");
                myAnimal = null;
                break;
        }

        if (myAnimal != null)
        {
            Console.WriteLine(myAnimal.Speak());
        }

        Console.WriteLine();

        List<Object> gameObjects = new List<Object>()
        {
            //new Airplane(15),
            new Dog(),
            new Cat(),
            new Park(),
            new Person("Jacob", "Banyard"),
            new Hunter("Majid", "Laklouk", "Nikon"),
            new Vehicle()
        };

        foreach (var obj in gameObjects)
        {
            Console.WriteLine($"{obj}'s hashcode is{obj.GetHashCode()}");
            if (obj is Animal)
            {
                Animal a = (Animal)obj;
                SpartaWrite(a.Speak());
            }
        }




        #endregion

    }


    public static void SpartaWrite(Object obj)
    {
        Console.WriteLine($"Sparta says: {obj}");
    }
}