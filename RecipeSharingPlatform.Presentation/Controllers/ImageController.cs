using Microsoft.AspNetCore.Mvc;

namespace RecipeSharingPlatform.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("download-image/{fileName}")]
        public IActionResult DownloadImage(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                if (!System.IO.File.Exists(filePath)) 
                    return NotFound("Image not found!");

                // Read the file and return it as a FileResult
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
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
