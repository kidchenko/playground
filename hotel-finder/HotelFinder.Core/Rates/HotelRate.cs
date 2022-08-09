using System;
namespace HotelFinder.Core.Rates
{
    public abstract record HotelRate
    {
        protected HotelRate(Money fare, RateType rateType)
        {
            Fare = fare;
            RateType = rateType;
        }

        public Money Fare { get; }
        public RateType RateType { get; }

        public abstract bool Statisfy(DateTime date, RateType rateType);
    }
}
