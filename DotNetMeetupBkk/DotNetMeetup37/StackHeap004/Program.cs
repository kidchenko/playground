using System;

namespace StackHeap004
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Info[] infos = { new Info(), new Info(), new Info(), new Info() };
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
