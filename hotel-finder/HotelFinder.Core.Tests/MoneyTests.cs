using FluentAssertions;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class MoneyTests
    {
        [Fact]
        public void ShouldCreateWithCurrency()
        {
            var money = Money.InDollars(10);
            money.Currency.Should().Be(Money.USD);
        }

        [Fact]
        public void ShouldCreateWithValue()
        {
            var money = Money.InDollars(10);
            money.Value.Should().Be(10);
        }

        [Fact]
        public void ShouldHaveSameReference()
        {
            var money = Money.InDollars(10);
            money.Should().Be(Money.InDollars(10));

            
        }

        [Fact]
        public void ShouldBeDifferent()
        {
            var money = Money.InDollars(10);
            money.Should().NotBe(Money.InDollars(5));
        }

        [Fact]
        public void ShouldBeNegative()
        {
            var money = Money.InDollars(-10);
            money.Should().Be(Money.InDollars(-10));
        }

        [Fact]
        public void ShouldBeVeryBig()
        {
            var money = Money.InDollars(9999999999999999999999M);
            money.Should().Be(Money.InDollars(9999999999999999999999M));
        }

        [Fact]
        public void ShouldBeVerySmall()
        {
            var money = Money.InDollars(-9999999999999999999999M);
            money.Should().Be(Money.InDollars(-9999999999999999999999M));
        }
    }
}
