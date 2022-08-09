using System;
using System.Collections.Generic;
using System.Linq;
using HotelFinder.Core.Rates;

namespace HotelFinder.Core
{
    public record Pricing
    {
        public Pricing()
        {

        }

        public Pricing(WeekdayRegularRate weekdayRegularRate,
                       WeekdayLoyaltyRate weekdayLoyaltyRate,
                       WeekendRegularRate weekendRegularRate,
                       WeekendLoyaltyRate weekendLoyaltyRate)
        {
            Rates = new List<HotelRate> {
                weekdayRegularRate,
                weekdayLoyaltyRate,
                weekendRegularRate,
                weekendLoyaltyRate
            };

            WeekdayRegularRate = weekdayRegularRate;
            WeekdayLoyaltyRate = weekdayLoyaltyRate;
            WeekendRegularRate = weekendRegularRate;
            WeekendLoyaltyRate = weekendLoyaltyRate;
        }

        private readonly IEnumerable<HotelRate> Rates;

        public WeekdayRegularRate WeekdayRegularRate { get; init; }
        public WeekdayLoyaltyRate WeekdayLoyaltyRate { get; init; }
        public WeekendRegularRate WeekendRegularRate { get; init; }
        public WeekendLoyaltyRate WeekendLoyaltyRate { get; init; }

        public Money RegularPrice(DateTime date)
        {
            var rate = Rates.Single(x => x.Statisfy(date, RateType.Regular));

            return rate.Fare;
            
        }

        public Money LoyaltyPrice(DateTime date)
        {
            var rate = Rates.Single(x => x.Statisfy(date, RateType.Loyalty));

            return rate.Fare;
        }

        public Money RegularPrice(DateRange range)
        {
            var price = Money.Zero;

            range.ForEachDay((DateTime date) => price += RegularPrice(date));

            return price;
        }

        public Money LoyaltyPrice(DateRange range)
        {
            var price = Money.Zero;

            range.ForEachDay((DateTime date) => price += LoyaltyPrice(date));

            return price;
        }
    }
}
