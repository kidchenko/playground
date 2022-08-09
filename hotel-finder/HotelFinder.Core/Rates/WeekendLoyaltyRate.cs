using System;

namespace HotelFinder.Core.Rates
{
    public record WeekendLoyaltyRate : HotelRate
    {
        public WeekendLoyaltyRate(Money rate) : base(rate, RateType.Loyalty) { }

        public override bool Statisfy(DateTime date, RateType rateType)
        {
            var isWeekend = date.IsWeekend();
            return isWeekend && this.RateType == rateType;
        }
    }
}
