using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.LocalArea;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalAreaController : BaseController
    {
        private ILocalAreaService _localAreaService;
        public LocalAreaController(ILocalAreaService localAreaService)
        {
            _localAreaService = localAreaService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<LocalAreaResponse>> CreateLocalArea(LocalAreaRequest model)
        {
            try
            {
                _localAreaService.AddLocalArea(model);
                return Ok(new { message = "Local Area successfully added" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<LocalAreaResponse>> Get()
        {
            var art = _localAreaService.GetAll();
            return Ok(art);
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<LocalAreaResponse>> Get(int id)
        {
            var artisan = _localAreaService.GetLocalArea(id);
            return Ok(artisan);
        }

        [HttpGet("getbystate/{id:int}")]
        public ActionResult<IEnumerable<LocalAreaResponse>> GetLocalArea(int id)
        {
            var artisan = _localAreaService.GetLocalAreaByState(id);
            return Ok(artisan);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteLocalArea(int id)
        {
            _localAreaService.Delete(id);
            return Ok(new { message = "Local Area deleted successfully" });
        }
    }
}