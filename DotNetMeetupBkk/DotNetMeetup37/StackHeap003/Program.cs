using System;

namespace StackHeap003
{
    class Program
    {
        static void Main(string[] args)
        {
            Info info = new Info();
            info.Name = "Hello";
        }
    }

    class Info
    {
        public int Id; // 4 bytes

        public double Value; // 8 bytes

        public DateTime Date; // 8 bytes

        public string Name;
    }
}
