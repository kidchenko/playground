using System;
namespace HotelManager.Core
{
    public record Money
    {
        private Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public static Money InDollars(decimal value)
        {
            return new Money(value, "USD");
        }

        public decimal Value { get; }
        public string Currency { get; }

        public static readonly Money Any = InDollars(0);

        public static readonly Money Zero = Any;

        public static Money operator +(Money moneyA, Money moneyB) 
        {
            return Money.InDollars(moneyA.Value + moneyB.Value);
        }
    }

    public static class MoneyExtensions
    {
        public static Money Dollars(this decimal value)
        {
            return Money.InDollars(value);
        }

        public static Money Dollars(this int value)
        {
            return Convert.ToDecimal(value).Dollars();
        }
    }
}
