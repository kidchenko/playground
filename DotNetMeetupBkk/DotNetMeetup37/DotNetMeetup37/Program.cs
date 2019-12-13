using System;

namespace GC001
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            #region Stack and GC
            var a = 1;
            Console.WriteLine(GC.GetGeneration(a));
            #endregion
        }
    }
}
