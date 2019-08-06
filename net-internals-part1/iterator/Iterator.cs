using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, world!");
    }

    static IEnumerator<int> Juca(int x)
    {
        yield return 42;
        yield return 10 / x ;
    }
}
