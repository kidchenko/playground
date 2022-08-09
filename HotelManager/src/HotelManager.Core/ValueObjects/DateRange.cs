using System;
namespace HotelManager.Core
{
    public record DateRange
    {
        public DateRange(DateTime checkin, DateTime checkout)
        {
            Checkin = checkin;
            CheckOut = checkout;


        }

        public DateTime Checkin { get; set; }

        public DateTime CheckOut { get; set; }

        public void ForEachDay(Action<DateTime> action) 
        {
            var date = Checkin;
            while(date <= CheckOut)
            {
                action(date);
                date = date.AddDays(1);
            }
        }
    }


}
