using System.Xml.Schema;

namespace ObjectEqualityAndComparisonApp;

public class Program
{
    static void Main()
    {
        var andrew = new Person("Andrew", "Ma") { Age = 99 };
        var phil = new Person("Philip", "Thomas") { Age = 99 };

        Console.WriteLine("Andrew and Phil are equal?: " + andrew.Equals(phil)); // comparing location/blocks/objects in memory, this is false
        Console.WriteLine($"Andrew and Phil are equal?: {andrew == phil}" ); // comparing location/blocks/objects in memory, this is false
        var andrewsClone = andrew;

        Console.WriteLine("Andrew and Andrew's clone are equal?: " + andrew.Equals(andrewsClone)); // both point to the same object in memory, yes this is true.

        List<int> list = new List<int> { 5, 1, 7, 99, 33 };
        list.Sort();

        foreach (int n in list) Console.Write(n);

        List<Person> people = new List<Person> { andrew, phil, andrewsClone, new Person("Talal", "Hassan"), new Person("Danyal", "Saleh") };

        people.Sort();


    }   
}