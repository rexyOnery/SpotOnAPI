using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Artisan;
using WebApi.Services;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtisanController : BaseController
    {
        private IArtisanService _artisanService;
        public ArtisanController(IArtisanService artisanService)
        {
            _artisanService = artisanService;
        }

        [HttpPost]
        public IActionResult CreateArtisan(ArtisanRequest model)
        {
            var artisan = _artisanService.AddArtisan(model);
            return Ok(new { message = artisan });
        }

        [HttpPost("filter")]
        public ActionResult<IEnumerable<ArtisanDisplayResponse>> FilterArtisan(ArtisanFilterRequest model)
        {
            var artisan = _artisanService.FilterArtisan(model);
            return Ok(artisan);
        }

        [HttpPost("filter-by-type")]
        public ActionResult<IEnumerable<ArtisanDisplayResponse>> FilterArtisanByType(ArtisanFilterRequest model)
        {
            var artisan = _artisanService.FilterArtisanByType(model);
            return Ok(artisan);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArtisanResponse>> Get()
        {
            var art = _artisanService.GetAll();
            return Ok(art);
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<ArtisanDisplayResponse>> GetArtisan(int id)
        {
            var artisan = _artisanService.GetArtisan(id);
            return Ok(artisan);
        }

        [HttpGet("getartisanbyaccountid/{id:int}")]
        public ActionResult<ArtisanResponse> GetArtisanByAccountId(int id)
        {
            var artisan = _artisanService.GetArtisanByAccountId(id);
            return Ok(artisan);
        }

        [HttpGet("pages")]
        public async Task<ActionResult<int>> GetPages()
        {
            return await _artisanService.GetPages();
        }

        [HttpGet("pages/{type:int}")]
        public async Task<ActionResult<int>> GetPages(int type)
        {
            return await _artisanService.GetPages(type);
        }

        [HttpGet("pagedartisans/{page:int}/{pagesize:int}")]
        public ActionResult<IEnumerable<ArtisanDisplayResponse>> GetArtisans(int page, int pageSize)
        {
            var pagedartisans = _artisanService.FindPaged(page, pageSize);
            return Ok(pagedartisans);
        }

        [HttpGet("pagedartisanstype/{category:int}/{page:int}/{pagesize:int}")]
        public ActionResult<IEnumerable<ArtisanDisplayResponse>> GetTypedArtisans(int category, int page, int pageSize)
        {
            var pagedartisans = _artisanService.FindPaged(category, page, pageSize);
            return Ok(pagedartisans);
        }

        [HttpGet("paged-artisans-typeid/{id:int}/{page:int}/{pagesize:int}")]
        public ActionResult<IEnumerable<ArtisanDisplayResponse>> GetArtisans(int id, int page, int pageSize)
        {
            var pagedartisans = _artisanService.FindPaged(id, page, pageSize);
            return Ok(pagedartisans);
        }




        [HttpPut("{id:int}")]
        public ActionResult<ArtisanResponse> UpdateArtisanPayment(int id)
        {
            var artisan = _artisanService.Update(id);
            if (artisan == null)
            {
                return Ok(new { message = "Artisan not found" });
            }
            else
            {
                return Ok(artisan);
            }
        }

        [HttpPut("photo/{id:int}")]
        public ActionResult<ArtisanResponse> UpdateArtisanPhoto(int id, PhotoRequest model)
        {
            var artisan = _artisanService.UpdatePhoto(id, model);
            if (artisan)
            {
                return Ok(new { message = "Upload Successful." });
            }
            else
            {
                return Ok(new { message = "Upload Not Uploaded." });
            }
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteArtisan(int id)
        {
            _artisanService.Delete(id);
            return Ok(new { message = "Artisan deleted successfully" });
        }
    }
}