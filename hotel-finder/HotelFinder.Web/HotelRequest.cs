using System;
namespace HotelFinder.Web
{
    public class HotelRequest
    {
        public HotelRequest()
        {
        }

        public string Name { get; set; }
        public int Rating { get; set; }
        public PriceRequest Prices { get; set; }
    }

    public class PriceRequest
    {
        public decimal WeekDayRegular { get; set; }
        public decimal WeekDayLoyalty { get; set; }
        public decimal WeekendRegular { get; set; }
        public decimal WeekendLoyalty { get; set; }
    }
}
