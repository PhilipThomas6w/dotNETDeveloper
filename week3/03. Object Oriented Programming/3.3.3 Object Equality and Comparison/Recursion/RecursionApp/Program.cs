namespace RecursionApp;

public class Program
{
    static void Main()
    {
        Console.WriteLine(GetFactorial(6));

        Console.WriteLine(GetFactorialRecursively(5));

        Console.WriteLine(GetFibonacciValue(5));

    }

    private static int GetFactorial(int num)
    {
        int numFactorial = 1;

        for (int i = 1; i <= num; i++)
        {
            numFactorial *= i;
        }
        return numFactorial;
    }

    private static int GetFactorialRecursively(int num)
    {
        if (num < 2) return 1;
        return num * GetFactorialRecursively(num - 1);
    }

    private static int GetFibonacciValue(int num)
    {
        if (num <= 0) throw new ArgumentException("Input must be greater than or equal to 1");
        if (num == 1) return 0;  
        if (num == 2) return 1;  

        else  // We now consider cases of 3 and above
        {
            int result = GetFibonacciValue(num - 1) + GetFibonacciValue(num - 2);
            return result;
        }
    }
}