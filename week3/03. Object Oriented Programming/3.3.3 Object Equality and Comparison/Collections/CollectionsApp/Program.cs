namespace CollectionsApp;

public class Program
{
    static void Main()
    {
        List<int> nums = new() { 1, 2, 3 };
        Console.WriteLine(nums[0]);

        Queue<int> myQ = new();
        myQ.Enqueue(1);
        myQ.Enqueue(2);
        myQ.Enqueue(3);

        while (myQ.Count > 0) Console.WriteLine(myQ.Dequeue());

        Stack<int> myStack = new();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);

        while (myStack.Count > 0) Console.WriteLine(myStack.Pop());

        List<int> challenge = new() { 5, 4, 3, 2, 1 };

        // Add 8 to the list
        challenge.Add(8);

        // Sort the list
        challenge.Sort();

        // Remove the 2 digits starting at position 1
        challenge.RemoveRange(1,2);

        // Insert the number 1 at position 2
        challenge.Insert(2, 1);

        // Reverse the list
        challenge.Reverse();


        // Remove the number 9
        challenge.Remove(9);

        // Write the list to the Console, all on one line
        foreach (var item in challenge) Console.Write(item);
        Console.WriteLine();


        // HashSets

        // every element in a hash set is unique

        var numberSet = new HashSet<int>() { 1, 2, 3 };

        Console.WriteLine(numberSet.Add(3));

        var peopleSet = new HashSet<Person>();

        peopleSet.Add(new Person("Matt", "Handley"));
        peopleSet.Add(new Person("Daniel", "Manu"));
        peopleSet.Add(new Person("Matt", "Handley"));

        foreach (var item in peopleSet) Console.WriteLine(item.GetFullName());

        // Dictionary
        // A collection of keys and values
        // 




        string input = "The cat in the hat comes back";  // letters will be my keys, values will be frequency

        Dictionary<char, int> myDictionary = new() { };

        foreach (var letter in input)
        {
            if (myDictionary.ContainsKey(letter))
            {
                myDictionary[letter]++;
            }
            else
            {
                myDictionary.Add(letter, 1);
            }
        }

        foreach (KeyValuePair<char, int> pair in myDictionary)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        
        



    }
}