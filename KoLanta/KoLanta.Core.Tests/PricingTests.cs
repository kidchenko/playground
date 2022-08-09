using System;
using FluentAssertions;
using Xunit;

namespace KoLanta.Core.Tests
{
    public class PricingTests
    {
        [Fact]
        public void ShouldCreate()
        {
            Pricing pricing = GetPricing();
            pricing.Should().NotBeNull();
        }

        [Fact]
        public void ShouldHaveAmount()
        {
            var pricing = GetPricing(amount: 110);
            pricing.Amount.Should().Be(110);
        }

        [Fact]
        public void ShouldHaveIsLoyality()
        {
            var pricing = GetPricing(isLoyalty: true);
            pricing.IsLoyality.Should().Be(true);
        }

        [Fact]
        public void ShouldHaveRegular()
        {
            var pricing = GetPricing(isLoyalty: false);
            pricing.IsRegular.Should().Be(true);
        }

        [Fact]
        public void ShoulBeEqualsAnotherPrice()
        {
            var pricing = GetPricing(amount: 10, isLoyalty: true);
            var anotherPricing = GetPricing(amount: 10, isLoyalty: true);

            pricing.Should().Be(anotherPricing);
        }

        private static Pricing GetPricing(decimal amount = 0M, bool isLoyalty = false)
        {
            return isLoyalty ? new LoyaltyPricing(amount) : new RegularPricing(amount);
        }
    }
}
