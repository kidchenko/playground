using System;
using System.Collections.Generic;
using System.Linq;
using HotelFinder.Core.Rates;

namespace HotelFinder.Core
{
    public class HotelManager
    {
        private IList<Hotel> Hotels { get; }

        public HotelManager(IList<Hotel> hotels)
        {
            Hotels = hotels;
        }

        public int Count()
        {
            return Hotels.Count;
        }

        public Hotel GetCheapestForLoyalty(DateRange dateRange)
        {
            var cheapest = Hotels
                .OrderBy(hotel => hotel.Pricing.LoyaltyPrice(dateRange).Value)
                .ThenByDescending(hotel => hotel.Rating.Value);

            return cheapest.First();
        }

        public Hotel GetCheapestForRegular(DateRange dateRange)
        {
            var cheapest = Hotels
                .OrderBy(hotel => hotel.Pricing.RegularPrice(dateRange).Value)
                .ThenByDescending(hotel => hotel.Rating.Value);

            return cheapest.First();
        }
    }
}
