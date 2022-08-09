using System;

namespace HotelFinder.Core.Rates
{
    public record WeekdayLoyaltyRate : HotelRate
    {
        public WeekdayLoyaltyRate(Money rate): base(rate, RateType.Loyalty)
        {

        }

        public override bool Statisfy(DateTime date, RateType rateType)
        {
            var isWeekend = date.IsWeekend();
            return !isWeekend && RateType == rateType;
        }
    }
}
