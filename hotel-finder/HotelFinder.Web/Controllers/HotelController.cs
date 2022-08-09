using System;
using System.Collections.Generic;
using System.Linq;
using HotelFinder.Core;
using HotelFinder.Core.Rates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelFinder.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly HotelManager hotelManager;
        private IList<Hotel> hotels;

        public HotelController(ILogger<HotelController> logger, IList<Hotel> hotels)
        {
            _logger = logger;
            this.hotels = hotels;
        }

        [HttpGet]
        public IEnumerable<HotelResponse> Get(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return hotels.Select(hotel => new HotelResponse(hotel));
            }

            var found = hotels.FirstOrDefault(hotel => hotel.Name.Value.ToLower().Contains(name.ToLower()));
            return found is null ? Array.Empty<HotelResponse>() : new[] { new HotelResponse(found) };
        }

        [HttpPost]
        public IActionResult Post(HotelRequest request)
        {
            // valid
            // insert in the db
            // map
            var rating = Rating.From(request.Rating);
            var name = HotelName.From(request.Name);
            var pricing = new Pricing {
                WeekdayRegularRate = new WeekdayRegularRate(Money.InDollars(request.Prices.WeekDayRegular)),
                WeekdayLoyaltyRate = new WeekdayLoyaltyRate(Money.InDollars(request.Prices.WeekDayLoyalty)),
                WeekendRegularRate = new WeekendRegularRate(Money.InDollars(request.Prices.WeekendRegular)),
                WeekendLoyaltyRate = new WeekendLoyaltyRate(Money.InDollars(request.Prices.WeekendLoyalty)),
            };
            var hotel = new Hotel(name, rating, pricing);

            hotels.Add(hotel);

            var response = new HotelResponse(hotel);

            return CreatedAtAction(nameof(Get), new { name = request.Name }, response);
        }
    }
}
