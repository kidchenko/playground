using System;

namespace HotelFinder.Core
{
    public sealed record Money
    {
        public static readonly string USD = "USD";

        private Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; }

        public string Currency { get; }


        public static Money InDollars(decimal value)
        {
            return new Money(value, USD);
        }

        public static readonly Money Any = InDollars(0);
        public static readonly Money Zero = Any;


        public static Money operator +(Money moneya, Money moneyb) => new(moneya.Value + moneyb.Value, moneya.Currency);
    }

    public static class MoneyExtensions
    {
        public static Money Dollars(this decimal value)
        {
            return Money.InDollars(value);
        }

        public static Money Dollars(this int value)
        {
            return Money.InDollars(Convert.ToDecimal(value));
        }
    }
}
