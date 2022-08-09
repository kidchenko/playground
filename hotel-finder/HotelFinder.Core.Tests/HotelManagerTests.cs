using System;
using System.Collections.Generic;
using FluentAssertions;
using HotelFinder.Core.Rates;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class HotelManagerTests
    {
        private HotelManager manager;

        public HotelManagerTests()
        {
            var parqueDasFlores = new Hotel(HotelName.From("Parque das Flores"),
              Rating.Three,
              new Pricing(
                  new WeekdayRegularRate(Money.InDollars(110)), new WeekdayLoyaltyRate(Money.InDollars(80)),
                  new WeekendRegularRate(Money.InDollars(90)), new WeekendLoyaltyRate(Money.InDollars(80))
                  )
            );

            var jardimBotanico = new Hotel(HotelName.From("Jardim Botanico"),
                          Rating.Four,
                          new Pricing(
                              new WeekdayRegularRate(Money.InDollars(160)), new WeekdayLoyaltyRate(Money.InDollars(110)),
                              new WeekendRegularRate(Money.InDollars(60)), new WeekendLoyaltyRate(Money.InDollars(50))));

            var marAtlantico = new Hotel(HotelName.From("Mar Atlantico"),
                          Rating.Five,
                          new Pricing(
                              new WeekdayRegularRate(Money.InDollars(220)), new WeekdayLoyaltyRate(Money.InDollars(100)),
                              new WeekendRegularRate(Money.InDollars(150)), new WeekendLoyaltyRate(Money.InDollars(40))));

            var hotels = new List<Hotel>(new[] {
                parqueDasFlores,
                jardimBotanico,
                marAtlantico
            });

            manager = new HotelManager(hotels);
        }

        [Fact]
        public void ShouldHaveThreeHotels()
        {
            manager.Count().Should().Be(3);
        }

        [Fact]
        public void ShouldFindTheCheapestForCase1()
        {
            var range = new DateRange
            {
                Checkin = new DateTime(2020, 3, 16),
                Checkout = new DateTime(2020, 3, 18)
            };

            var hotel = manager.GetCheapestForRegular(range);

            hotel.Name.Should().Be(HotelName.From("Parque das Flores"));
        }

        [Fact]
        public void ShouldFindTheCheapestForCase2()
        {
            var range = new DateRange
            {
                Checkin = new DateTime(2020, 3, 20),
                Checkout = new DateTime(2020, 3, 22)
            };
            var hotel = manager.GetCheapestForRegular(range);

            hotel.Name.Should().Be(HotelName.From("Jardim Botanico"));
        }

        [Fact]
        public void ShouldFindTheCheapestForCase3()
        {
            var range = new DateRange
            {
                Checkin = new DateTime(2020, 3, 26),
                Checkout = new DateTime(2020, 3, 28)
            };

            var hotel = manager.GetCheapestForLoyalty(range);

            hotel.Name.Should().Be(HotelName.From("Mar Atlantico"));
        }
    }
}
