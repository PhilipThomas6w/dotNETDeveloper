﻿namespace IntroToCSharp;

public class Program
{
    static void Main()
    {
        // Console.WriteLine("Hello World!");

        int x = 100;
        x += 10;    // is same as x = x + 10;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("i is: " + i + " , x is: " + x);
            x += i;     
        }        
    }
}

