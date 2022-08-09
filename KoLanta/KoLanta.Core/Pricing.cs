using System;
namespace KoLanta.Core
{
    public abstract record Pricing
    {
        public Pricing(decimal amount, bool isLoyality)
        {
            Amount = amount;
            IsLoyality = isLoyality;
        }

        public decimal Amount { get; }
        public bool IsLoyality { get; }
        public bool IsRegular => !IsLoyality;
    }

    public record RegularPricing : Pricing
    {
        public RegularPricing(decimal amount) : base(amount, false)
        {
        }
    }

    public record LoyaltyPricing : Pricing
    {
        public LoyaltyPricing(decimal amount) : base(amount, true)
        {
        }
    }
}
