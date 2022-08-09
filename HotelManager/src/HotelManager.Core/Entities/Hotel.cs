using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManager.Core
{
    public record HotelName
    {
        private HotelName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static HotelName From(string name)
        {
            return new HotelName(name);
        }

    }

    public class Hotel
    {
        public Hotel(
            HotelName name,
            Rating rating,
            Money weekDayRateRegular,
            Money weekDayRateLoyalty,
            Money weekendRateRegular,
            Money weekendRateLoyalty)
        {
            Name = name;
            Rating = rating;
            WeekDayRateRegular = weekDayRateRegular;
            WeekDayRateLoyalty = weekDayRateLoyalty;
            WeekendRateRegular = weekendRateRegular;
            WeekendRateLoyalty = weekendRateLoyalty;
            rates = new List<HotelRate>
            {

                new WeekendLoyaltyRate(WeekendRateLoyalty),
                new WeekendRegularRate(WeekendRateRegular),
                new WeekdayLoyaltyRate(WeekDayRateLoyalty),
                new WeekdayRegularyRate(WeekDayRateRegular)
            };
        }

        public HotelName Name { get; }

        public Rating Rating { get; init; }

        public Money WeekDayRateRegular { get; init; }

        public Money WeekDayRateLoyalty { get; init; }

        public Money WeekendRateRegular { get; init; }

        public Money WeekendRateLoyalty { get; init; }

        private readonly List<HotelRate> rates;

        public Money GetRegularPrice(DateTime date)
        {
            var rate = rates.Single(rate => rate.Satisfy(date, false)); 

            return rate.Price;
        }

        public Money GetRegularPrice(DateRange range)
        {
            var price = Money.Zero;

            range.ForEachDay((date) => {
                var priceOnDate = GetRegularPrice(date);
                price = price + priceOnDate;
            });

            return price;
        }

        public Money GetLoyaltyPrice(DateTime date)
        {
            var rate = rates.Single(rate => rate.Satisfy(date, true));

            return rate.Price;
        }

        public Money GetLoyaltyPrice(DateRange range)
        {
            var price = Money.Zero;

            range.ForEachDay((date) => {
                var priceOnDate = GetLoyaltyPrice(date);
                price = price + priceOnDate;
            });

            return price;
        }
    }
}
