using System;
using System.Linq;
using HotelFinder.Core.Rates;

namespace HotelFinder.Core
{
    public class Hotel
    {
        public Hotel()
        {

        }

        public Hotel(HotelName name, Rating rating, Pricing pricing)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Rating = rating ?? throw new ArgumentNullException(nameof(rating));
            Pricing = pricing ?? throw new ArgumentNullException(nameof(pricing));
        }

        public long Id { get; protected set; }

        public HotelName Name { get; }

        public Rating Rating { get; }

        public Pricing Pricing { get; }

    }
}
