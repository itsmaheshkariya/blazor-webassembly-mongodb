using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fullstack.Shared;
using Fullstack.Server.Services;
namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET api/user
        [HttpGet("")]
        public ActionResult<List<User>> Getstrings()
        {
            return _userService.GetUsers();
        }

        // GET api/user/5
        [HttpGet("{id:length(24)}")]
        public ActionResult<User> GetstringById(string id)
        {
            return _userService.GetUser(id);
        }

        // POST api/user
        [HttpPost("")]
        public User Poststring(User user)
        {
            _userService.PostUser(user);
            return user;
        }

        // PUT api/user/5
        [HttpPut("{id:length(24)}")]
        public User Putstring(string id, User newUser)
        {
           return _userService.PutUser(id,newUser);

        }

        // DELETE api/user/5
        [HttpDelete("{id:length(24)}")]
        public User DeletestringById(string id)
        {
            return _userService.DeleteUser(id);
        }
    }
}
