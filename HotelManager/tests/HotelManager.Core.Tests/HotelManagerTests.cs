using System;
using FluentAssertions;
using Xunit;

namespace HotelManager.Core.Tests
{
    public class HotelManagerTests
    {
        private HotelManager hotelManager;

        public HotelManagerTests()
        {
            hotelManager = new HotelManager();
        }

        [Fact]
        public void ShouldCreateHotel()
        {
            hotelManager.Should().NotBeNull();
        }

        [Fact]
        public void ShouldGetCase1()
        {
            var monday = new DateTime(2020, 03, 16);
            var wednesday = new DateTime(2020, 03, 18);
            var range = new DateRange(monday, wednesday);

            var hotel = hotelManager.FindCheapest(range, false);

            hotel.Name.Value.Should().Be("Parque das Flores");
        }

        [Fact]
        public void ShouldGetCase2()
        {
            var friday = new DateTime(2020, 03, 20);
            var sunday = new DateTime(2020, 03, 22);
            var range = new DateRange(friday, sunday);

            var hotel = hotelManager.FindCheapest(range, false);

            hotel.Name.Value.Should().Be("Jardim Botanico");
        }

        [Fact]
        public void ShouldGetCase3()
        {
            var thursday = new DateTime(2020, 03, 26);
            var saturday = new DateTime(2020, 03, 28);
            var range = new DateRange(thursday, saturday);


            var hotel = hotelManager.FindCheapest(range, true);

            hotel.Name.Value.Should().Be("Mar Atlantico");
        }
    }
}
