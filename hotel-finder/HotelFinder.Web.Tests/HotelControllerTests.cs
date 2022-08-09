using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HotelFinder.Core;
using HotelFinder.Core.Rates;
using HotelFinder.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace HotelFinder.Web.Tests
{
    public class HotelControllerTests
    {
        private readonly HotelController controller;
        private List<Hotel> hotels;

        public HotelControllerTests()
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


            hotels = new List<Hotel>(new[]
            {
                parqueDasFlores,
                jardimBotanico,
                marAtlantico
            });

            var logger = Substitute.For<ILogger<HotelController>>();
            controller = new HotelController(logger, hotels);
        }


        [Fact]
        public void GetAll()
        {
            var result = controller.Get();

            result.Count().Should().Be(3);
        }

        [Fact]
        public void GetByName()
        {
            var result = controller.Get(name: "Parque");

            result.Count().Should().Be(1);
            result.First().Name.Should().Be("Parque das Flores");
        }

        [Fact]
        public void GetByNameNotFound()
        {
            var result = controller.Get(name: "NotFound");

            result.Count().Should().Be(0);
            // test controller performance
            //await someAsyncWork.Should().CompleteWithinAsync(100.Milliseconds());
        }

        [Fact]
        public void PostHotel()
        {
            var result = controller.Post(new HotelRequest()
            {
                Name = "New Hotel",
                Rating = 1,
                Prices = new PriceRequest()
                {
                    WeekDayRegular = 100,
                    WeekDayLoyalty = 75,
                    WeekendRegular = 200,
                    WeekendLoyalty = 150
                }
            });

            controller.ModelState.IsValid.Should().BeTrue();
            result.Should().BeOfType<CreatedAtActionResult>();
        }

        [Fact]
        public void PostHotelInvalidRating()
        {
            var hotel = new HotelRequest()
            {
                Name = "New Hotel",
                Rating = 0,
                Prices = new PriceRequest()
                {
                    WeekDayRegular = 100,
                    WeekDayLoyalty = 75,
                    WeekendRegular = 200,
                    WeekendLoyalty = 150
                }
            };

            Action action = () => controller.Post(hotel);
            action.Should().Throw<InvalidOperationException>().WithMessage("Invalid Rating.");
        }
    }
}
