using System;
namespace KoLanta.Core
{
    public class Hotel
    {
        public Hotel(string name, Rating rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name { get; private set; }
        public Rating Rating { get; private set; }

        public void GetPrice(DateTime date, bool isLoyalty)
        {
            throw new NotImplementedException();
        }
    }
}
