using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeolocationAPI.Models;
using GeolocationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GeolocationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet(Name = "GetLocation")]
        public ActionResult<List<Location>> Get([FromBody] UserLocationRequest request)
        {
            var item = _locationService.Get(request.UserID, request.CardNumber);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Location> Create(Location location)
        {
            _locationService.Create(location);

            return CreatedAtRoute("GetLocation", new { id = location.Id.ToString() }, location);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] UserLocationRequest request)
        {
            var item = _locationService.Get(request.UserID, request.CardNumber);

            if (item == null)
            {
                return NotFound();
            }

            _locationService.Remove(request.UserID, request.CardNumber);

            return NoContent();
        }
    }

    public class UserLocationRequest
    {

        [JsonProperty("UserID")]
        public string UserID { get; set; }

        [JsonProperty("CardNumber")]
        public string CardNumber { get; set; }

    }
}
