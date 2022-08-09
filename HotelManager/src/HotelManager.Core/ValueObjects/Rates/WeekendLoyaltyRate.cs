using System;
namespace HotelManager.Core
{
    public class WeekendLoyaltyRate : HotelRate
    {
        public WeekendLoyaltyRate(Money rate) : base(rate, true) { }

        public override bool Satisfy(DateTime date, bool isLoyalty)
        {
            return date.IsWeekend() && isLoyalty;
        }
    }
}
