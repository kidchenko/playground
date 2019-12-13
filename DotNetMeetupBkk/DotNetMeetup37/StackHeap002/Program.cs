using System;

namespace StackHeap002
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 20;
            string s = "Hello World";
            Info info = new Info();
            //info.Name = "Hello";
        }
    }

    internal struct Info
    {
        public int Id; // 4 bytes
        
        public double Value; // 8 bytes

        public DateTime Date; // 8 bytes

        //public string Name;
    }
}
