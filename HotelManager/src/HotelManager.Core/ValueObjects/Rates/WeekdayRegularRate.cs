using System;
namespace HotelManager.Core
{
    public class WeekdayRegularyRate : HotelRate
    {
        public WeekdayRegularyRate(Money rate) : base(rate, false) { }

        public override bool Satisfy(DateTime date, bool isLoyalty)
        {
            return !date.IsWeekend() && !isLoyalty;
        }
    }
}
