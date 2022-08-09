using System;
namespace HotelManager.Core
{
    public abstract class HotelRate
    {
        public HotelRate(Money rate, bool isLoyalty)
        {
            Price = rate;
            IsLoyalty = isLoyalty;
        }

        public Money Price { get; }
        public bool IsLoyalty { get; }

        public abstract bool Satisfy(DateTime date, bool isLoyalty);
    }

    public static class DateExtensions
    {
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
