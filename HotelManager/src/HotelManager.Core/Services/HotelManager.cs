using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManager.Core
{
    public class HotelManager
    {
        private List<Hotel> hotels;

        public HotelManager()
        {
            hotels = new List<Hotel>();

            hotels.Add(new Hotel(HotelName.From("Parque das Flores"), Rating.Three, 110.Dollars(), 80.Dollars(), 90.Dollars(), 80.Dollars()));
            hotels.Add(new Hotel(HotelName.From("Jardim Botanico"), Rating.Four, 160.Dollars(), 110.Dollars(), 60.Dollars(), 50.Dollars()));
            hotels.Add(new Hotel(HotelName.From("Mar Atlantico"), Rating.Five, 220.Dollars(), 100.Dollars(), 150.Dollars(), 40.Dollars()));
        }

        public Hotel FindCheapest(DateRange range, bool isLoyalty)
        {
            if (isLoyalty)
            {
                var cheapest = hotels
                .OrderBy(hotel => hotel.GetLoyaltyPrice(range).Value)
                .ThenByDescending(hotel => hotel.Rating.Value).First();
                return cheapest;
            }
            else
            {
                var cheapest = hotels
                .OrderBy(hotel => hotel.GetRegularPrice(range).Value)
                .ThenByDescending(hotel => hotel.Rating.Value).First();
                return cheapest;
            }            
        }
    }
}
