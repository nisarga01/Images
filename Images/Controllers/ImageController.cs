using Images.DTO;
using Images.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Images.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageServices imageService;
        public ImageController(IImageServices imageService)
        {
            this.imageService = imageService;
        }

        [EnableCors("CORSPolicy")]
        [HttpPost("addImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageRequestDTO request)
        {
            var Result = await imageService.addImageAsync(request);
            if (Result.Success)
                return Ok(Result);
            return BadRequest(Result);
        }
    }
}

