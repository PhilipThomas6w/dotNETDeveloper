using System;

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

        // Object initialisers
        var patrick = new Person("Patrick", "Ardagh") { Age = 25, Height = 300 }; // Note how similar this syntax is to the syntax used to create lists and arrays.

        // Longform way of initialising 
        var matthew = new Person("Matthew", "Handley");
        matthew.Age = 21;
        matthew.Height = 150;
        
        List<int> myList = new List<int>() { 1, 2, 3 };  // This code serves no purpose; it's just here to illustrate the point above
        int[] array = new int[] { 1, 2, 3 }; // This code serves no purpose; it's just here to illustrate the point above

        Park park = new Park() { Roundabouts = 1, Swings = 1, ParkManager = new Person("Dave", "Davidson")};




        var myDog = new Dog();
        var myCat = new Cat();
        var myBird = new Bird();

        Console.WriteLine(myDog(Speak));
        Console.WriteLine(myCat(Speak));
        Console.WriteLine(myBird(Speak));

        Console.WriteLine("\nPolymorphism demo: \n");

        List<Animal> animals = new List<Animal>() { myDog, myCat, myBird };
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.Speak());
        }

        Console.WriteLine(); // Just for a line space

        Animal? myAnimal;

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
                myBird = new Bird();
                break;
            default:
                Console.WriteLine("Not an animal :(");
                myAnimal = null;
                break;
        }

        if (myAnimal is not null) Console.WriteLine(myAnimal.Speak());

    }
}