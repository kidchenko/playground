using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, world!");
        var result = JucaIntAsync().Result;
    }



    static async void JucaVoidAsync()
    {
        var result = await JucaIntAsync();
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
