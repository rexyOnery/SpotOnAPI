using Microsoft.AspNetCore.Mvc;
using WebApi.Models.PresidentialVote;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresidentialVoteController : BaseController
    {
        private IPresidentialVoteService _IPresidentialVoteService;
        public PresidentialVoteController(IPresidentialVoteService presidentialVoteService)
        {
            _IPresidentialVoteService = presidentialVoteService;
        }

        [HttpPost]
        public IActionResult CreatePresidentialVote(PresidentialVoteRequest model)
        {
            var presidentialVote = _IPresidentialVoteService.AddPresidentialVote(model);
            return Ok(new { message = presidentialVote });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var presidentialVotes = _IPresidentialVoteService.GetAll();
            return Ok(new { message = presidentialVotes });
        }

        [HttpGet("{id}")]
        public IActionResult GetPresidentialVoteById(int id)
        {
            var presidentialVote = _IPresidentialVoteService.GetPresidentialVoteById(id);
            return Ok(new { message = presidentialVote });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IPresidentialVoteService.Delete(id);
            return Ok(new { message = "Deleted" });
        }
    }
}