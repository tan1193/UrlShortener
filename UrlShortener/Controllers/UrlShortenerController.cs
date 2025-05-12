using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlShortenerController : ControllerBase
    {
        private static readonly Dictionary<string, string> Urls = new();

        private readonly ILogger<UrlShortenerController> _logger;

        public UrlShortenerController(ILogger<UrlShortenerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("shorten")]
        public  IResult ShortenUrl(UrlRequest req)
        {
            var shortCode = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                              .Replace("=", "").Replace("+", "").Substring(0, 6);

            Urls[shortCode] = req.OriginalUrl;

            return Results.Ok(new { shortUrl = $"http://localhost:5000/{shortCode}" });
        }

        [HttpGet("{code}")]
        public  IResult GetUrlByCode(string code)
        {
            if (Urls.TryGetValue(code, out var originalUrl))
            {
                return Results.Ok(originalUrl);
            }

            return Results.NotFound();
        }
    }
    public record UrlRequest(string OriginalUrl);
}
