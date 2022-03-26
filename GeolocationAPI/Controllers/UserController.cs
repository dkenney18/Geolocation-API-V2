using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeolocationAPI.Models;
using GeolocationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeolocationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var item = _userService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<User> Create(User item)
        {
            _userService.Create(item);

            return CreatedAtRoute("GetUser", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User itemIn)
        {
            var item = _userService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _userService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var item = _userService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _userService.Remove(item.Id);

            return NoContent();
        }
    }
}
