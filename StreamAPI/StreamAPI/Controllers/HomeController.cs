using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace StreamAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("stream/{fileName}")]
        public IActionResult StreamVideo(string fileName)
        {
            var filePath = Path.Combine("Videos", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Video not found.");
            }

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(stream, "video/mp4", enableRangeProcessing: true);
        }
    }
}
