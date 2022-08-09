using System;
using FluentAssertions;
using Xunit;

namespace HotelManager.Core.Tests
{
    public class MoneyTests
    {
        public bool DoSomething(string userName, string password)
        {
            return false;
        }


        [Fact]
        public void ShouldCreateMoneyWithValue()
        {
            string name = "Jose";
            name = "Barbosa";
            name = 17;


            bool isCreatingBugs = true;



            dynamic myName = "Jose";
            dynamic myAge = 25;
            dynamic isDeveloper = true;








            Console.WriteLine(juca.GetType());

            Money money = Money.InDollars(100);

            money.Value.Should().Be(100);
        }

        [Fact]
        public void ShouldBeTheSameWhenSameValue()
        {
            var tenDollar = Money.InDollars(10);

            tenDollar.Should().Be(Money.InDollars(10));
        }

        [Fact]
        public void ShouldCreateMoneyWithCurrency()
        {
            var money = Money.InDollars(100);

            money.Currency.Should().Be("USD");
        }

        [Fact]
        public void ShouldCreateMoneyWithVeryBigValue()
        {
            var bigValue = 999999999999999;
            var money = Money.InDollars(bigValue);

            money.Value.Should().Be(bigValue);
        }

        [Fact]
        public void ShouldCreateMoneyWithVerySmallValue()
        {
            var smallValue = -999999999999999;
            var money = Money.InDollars(smallValue);

            money.Value.Should().Be(smallValue);
        }

        [Fact]
        public void ShouldCreateMoneyOnlyInUSD()
        {
            var smallValue = -999999999999999;
            var money = Money.InDollars(smallValue);

            money.Value.Should().Be(smallValue);
        }

        [Fact]
        public void ShouldSumTwoMoney()
        {
            var money1 = Money.InDollars(10);
            var money2 = 10.Dollars();

            (money1  + money2).Should().Be(20.Dollars());
        }
    }
}
