using System;
namespace HotelManager.Core
{
    public class WeekendRegularRate : HotelRate
    {
        public WeekendRegularRate(Money rate): base(rate, false) { }

        public override bool Satisfy(DateTime date, bool isLoyalty)
        {
            return date.IsWeekend() && false == isLoyalty;
        }
    }
}
