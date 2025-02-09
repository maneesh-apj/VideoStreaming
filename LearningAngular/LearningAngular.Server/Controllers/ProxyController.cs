using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProxyController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("stream/{fileName}")]
        public async Task<IActionResult> StreamVideo(string fileName)
        {
            var videoStreamApiUrl = $"https://localhost:44356/stream/{fileName}";
            var response = await _httpClient.GetAsync(videoStreamApiUrl, HttpContext.RequestAborted);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error streaming video.");
            }

            var stream = await response.Content.ReadAsStreamAsync();
            return new FileStreamResult(stream, response.Content.Headers.ContentType?.ToString() ?? "video/mp4")
                {
                EnableRangeProcessing = true
            };
        }
    }
}
