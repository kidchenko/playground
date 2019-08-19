using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        Demo();
        Console.ReadLine();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Demo()
    {
        int x = Add(1, 2);
        Console.WriteLine(x);

        int y = Add(2, 3);
        Console.WriteLine(y);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int Add(int a, int b)
    {
        return a + b;
    }
}
