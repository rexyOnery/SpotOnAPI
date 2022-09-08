using WebApi.Services;
using WebApi.Models.Gallery;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GalleryController : BaseController
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<GalleryResponse>> Get(int id)
        {
            var gals = _galleryService.GetAll(id);
            return Ok(gals);
        }

        [HttpGet("getallartisanphoto/{id:int}")]
        public ActionResult<IEnumerable<GalleryResponse>> GetAllArtisanPhoto(int id)
        {
            var gals = _galleryService.GetAllArtisanPhoto(id);
            return Ok(gals);
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult UploadFile(GalleryRequests model)
        {

            try
            {
                // save 
                var _photo = _galleryService.AddPhoto(model);
                if (_photo)
                {
                    return Ok(new { message = "The file was successfully uploaded" });
                }
                else
                    return BadRequest(new { message = "Image not uploaded, Please try again!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _galleryService.Delete(id);
            return Ok(new { message = "gallery item deleted successfully" });
        }

    }

}