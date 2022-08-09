using System;
namespace HotelManager.Core
{
    public class WeekdayLoyaltyRate : HotelRate
    {
        public WeekdayLoyaltyRate(Money rate) : base(rate, true) { }

        public override bool Satisfy(DateTime date, bool isLoyalty)
        {
            return !date.IsWeekend() && isLoyalty;
        }
    }
}
