using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class USerController : BaseController
    {
        private IUserService _userService;
        public USerController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(UserRequest model)
        {
            var user = _userService.AddUser(model);
            return Ok(new { message = user });
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> Get()
        {
            var art = _userService.GetAll();
            return Ok(art);
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserResponse> GetUser(int id)
        {
            var user = _userService.GetUserByAccountId(id);
            return Ok(user);
        }

        [HttpGet("id/{id:int}")]
        public ActionResult<UserResponse> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }

    }
}