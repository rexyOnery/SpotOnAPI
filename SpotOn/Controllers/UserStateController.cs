using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.UserState;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserStateController : BaseController
    {
        private IUserStateService _userStateService;
        public UserStateController(IUserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<UserStateResponse>> CreateUserState(UserStateRequest model)
        {
            try
            {
                _userStateService.AddUserState(model);
                return Ok(new { message = "State successfully added" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserStateResponse>> Get()
        {
            var user_states = _userStateService.GetAll();
            return Ok(user_states);
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserStateResponse> Get(int id)
        {
            var user_state = _userStateService.GetUserState(id);
            return Ok(user_state);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUserState(int id)
        {
            _userStateService.Delete(id);
            return Ok(new { message = "State deleted successfully" });
        }

    }
}