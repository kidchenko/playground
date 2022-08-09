using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFiveSimple.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WeatherController(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        [Authorize]
        [HttpGet]
        public IActionResult HelloWold() 
        {
            try
            {
                var userRole =
                    _httpContextAccessor?.HttpContext?.User?.Claims.Select(claim => new { claim.Type, claim.Value });
                return Ok(userRole);
            }
            catch (Exception)
            {
                // Log
            }

            return NotFound();
        }

        // [Authorize("Firebase")]
        // public IActionResult HelloWoldFireBase()
        // {
        //     return Ok();
        // }
    }
}
