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

        [HttpGet]
        public ActionResult<IEnumerable<GalleryResponse>> Get()
        {
            var gals = _galleryService.GetAll();
            return Ok(gals);
        }

        [HttpPost("addgallery"), DisableRequestSizeLimit]
        public IActionResult UploadFile(GalleryRequests model)
        {

            try
            {
                // save 
                var _photo = _galleryService.AddPhoto(model);
                if (_photo.Count() > 0)
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