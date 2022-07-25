using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Artisan;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtisanTypeController : BaseController
    {
        private IArtisanTypeService _artisanTypeService;
        public ArtisanTypeController(IArtisanTypeService artisanTypeService)
        {
            _artisanTypeService = artisanTypeService;
        }

        public ActionResult<IEnumerable<ArtisanTypeResponse>> CreateArtisanType(ArtisanTypeRequest model)
        {
            try
            {
                _artisanTypeService.AddArtisanType(model);
                return Ok(new { message = "Artisan Type successfully added" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<ArtisanTypeResponse> Get(int id)
        {
            var artisan = _artisanTypeService.GetArtisanType(id);
            return Ok(artisan);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArtisanTypeResponse>> GetAll()
        {
            var art = _artisanTypeService.GetAll();
            return Ok(art);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _artisanTypeService.Delete(id);
            return Ok(new { message = "Artisan Type deleted successfully" });
        }

    }
}