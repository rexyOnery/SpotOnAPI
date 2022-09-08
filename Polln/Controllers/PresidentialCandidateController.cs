using Microsoft.AspNetCore.Mvc;
using WebApi.Models.PresidentialCandidate;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresidentialCandidateController : BaseController
    {
        private IPresidentialCandidateService _presidentialCandidateService;
        public PresidentialCandidateController(IPresidentialCandidateService presidentialCandidateService)
        {
            _presidentialCandidateService = presidentialCandidateService;
        }

        [HttpPost]
        public IActionResult CreatePresidentialCandidate(PresidentialCandidateRequest model)
        {
            var presidentialCandidate = _presidentialCandidateService.AddPresidentialCandidate(model);
            return Ok(new { message = presidentialCandidate });
        }

        [HttpPost("photo")]
        public IActionResult CreatePresidentialCandidatePhoto(PresidentialCandidatePhotoRequest model)
        {
            var presidentialCandidate = _presidentialCandidateService.AddPresidentialCandidatePhoto(model);
            return Ok(new { message = presidentialCandidate });
        }

        [HttpPost("partylogo")]
        public IActionResult CreatePresidentialCandidatePartyLogo(PresidentialCandidatePartyLogoRequest model)
        {
            var presidentialCandidate = _presidentialCandidateService.AddPresidentialCandidatePartyLogo(model);
            return Ok(new { message = presidentialCandidate });
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var presidentialCandidates = _presidentialCandidateService.GetAll();
            return Ok(new { message = presidentialCandidates });
        }

        [HttpGet("{id}")]
        public IActionResult GetPresidentialCandidateById(int id)
        {
            var presidentialCandidate = _presidentialCandidateService.GetPresidentialCandidateById(id);
            return Ok(new { message = presidentialCandidate });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _presidentialCandidateService.Delete(id);
            return Ok(new { message = "Deleted" });
        }
    }
}