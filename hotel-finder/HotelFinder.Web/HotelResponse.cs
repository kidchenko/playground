using System;
using HotelFinder.Core;

namespace HotelFinder.Web
{
    public class HotelResponse
    {
        public HotelResponse(Hotel hotel)
        {
            Name = hotel.Name.Value; ;
            Rating = hotel.Rating.Value;
            Prices = new PriceResponse
            {
                WeekDayRegular = hotel.Pricing.WeekdayRegularRate.Fare.Value,
                WeekDayLoyalty = hotel.Pricing.WeekdayLoyaltyRate.Fare.Value,
                WeekendRegular = hotel.Pricing.WeekendRegularRate.Fare.Value,
                WeekendLoyalty = hotel.Pricing.WeekendLoyaltyRate.Fare.Value
            };
        }

        public string Name { get; set; }
        public int Rating { get; set; }

        public PriceResponse Prices { get; set; }
    }

    public class PriceResponse
    {
        public decimal WeekDayRegular { get; set; }
        public decimal WeekDayLoyalty { get; set; }
        public decimal WeekendRegular { get; set; }
        public decimal WeekendLoyalty { get; set; }

    }
}
