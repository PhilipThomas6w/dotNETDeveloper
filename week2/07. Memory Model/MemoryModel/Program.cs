namespace MemoryModel;

public class Program
{
    static void Main()
    {
        // Value types
        var num1 = 10;
        var num2 = num1;
        num1++;
        Console.WriteLine($"num1: {num1} , num2: {num2}");

        // Why didn't num2 increment when we incremented num1? Because the value of num2 was copied from the value of num1 before the value of num1 was incremented.

        // Reference types
        string[] animals = {"cows", "dogs", "lions"};

        var mammals = animals;
        mammals[0] = "cats";
        

        foreach (var animal in animals)
        {
            Console.WriteLine();
        }

        // Why did the first item in animals change? 
        // Because a string array is a reference type. Both animals and mammals contain the address of {"cows", "dogs", "lions"}. When we copied 'animals', we copied the !address!, not the values.   

        // some types are "value" types, some are "reference" types.
        // value types

        int ahmed = 10;
        int[] idris = { -9, -8, -7 };

        PassByRefDemo(ahmed, idris);

    }

    private static void PassByRefDemo(int majid, int[] nooreen)
    {
        majid /= 2;

        for (int nathan = 0; nathan < nooreen.Length; nathan++) // nathan is simply an index
        {
            nooreen[nathan] = Math.Abs(nooreen[nathan]);
        }

        
    }

    // Obviously this code is difficult to read, but it is demonstrating that the name of the argument doesn't have to match the name of the parameter - it is the type of the argument that decides how it 
    // gets passed into the method. majid is the parameter i.e., a bound variable, and the value of ahmed will be passed as the value of majid when the method is called.



}