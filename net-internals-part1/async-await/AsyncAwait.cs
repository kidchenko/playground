using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, world!");
    }

    static async void JucaVoidAsync()
    {
        return;
    }

    static async Task JucaTaskAsync()
    {
        throw new NotImplementedException();
    }

    static async Task<int> JucaIntAsync()
    {
        return 42;
    }
}
