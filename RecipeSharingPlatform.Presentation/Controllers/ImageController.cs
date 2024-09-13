using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Application.Services.Interfaces;

namespace RecipeSharingPlatform.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("download-image/{fileName}")]
        public async Task<IActionResult> DownloadImage(string fileName)
        {
            try
            {
                var fileBytes = await _imageService.GetImageAsync(fileName);
                var contentType = "application/octet-stream";
                return File(fileBytes, contentType, fileName);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
