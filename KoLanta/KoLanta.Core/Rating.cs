using System;
namespace KoLanta.Core
{
    public class Rating
    {
        private Rating(int value)
        {
            this.value = value;
        }

        public static readonly Rating One = new(1);
        public static readonly Rating Two = new(2);
        public static readonly Rating Three = new(3);
        public static readonly Rating Four = new(4);
        public static readonly Rating Five = new(5);


        private readonly int value;
    }
}
