using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using UrlShortener.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;

namespace UrlShortener.Tests
{
    public class UrlShortenerControllerTests
    {
        private readonly Mock<ILogger<UrlShortenerController>> _loggerMock;

        public UrlShortenerControllerTests()
        {
            _loggerMock = new Mock<ILogger<UrlShortenerController>>();
        }

        [Fact]
        public void ShortenUrl_ReturnsShortUrl()
        {
            // Arrange
            var controller = new UrlShortenerController(_loggerMock.Object);
            var request = new UrlRequest("https://example.com");

            // Act
            var result = controller.ShortenUrl(request);

            // Assert
            var okResult = Assert.IsType<Ok<object>>(result);
            var value = okResult.Value as dynamic;
            Assert.NotNull(value);
            if (value is not null)
            {
                string shortUrl = value.shortUrl;
                Assert.StartsWith("http://localhost:5000/", shortUrl);
                Assert.Equal(28, shortUrl.Length); // 22 + 6
            }
        }

        [Fact]
        public void GetUrlByCode_ReturnsOriginalUrl_WhenCodeExists()
        {
            // Arrange
            var controller = new UrlShortenerController(_loggerMock.Object);
            var request = new UrlRequest("https://test.com");
            var shortenResult = controller.ShortenUrl(request);
            var okResult = Assert.IsType<Ok<object>>(shortenResult);
            var value = okResult.Value as dynamic;
            if (value is not null)
            {
                string shortUrl = value.shortUrl;
                string code = shortUrl.Split('/').Last();

                // Act
                var getResult = controller.GetUrlByCode(code);

                // Assert
                var getOkResult = Assert.IsType<Ok<string>>(getResult);
                Assert.Equal("https://test.com", getOkResult.Value);
            }

        }

        [Fact]
        public void GetUrlByCode_ReturnsNotFound_WhenCodeDoesNotExist()
        {
            // Arrange
            var controller = new UrlShortenerController(_loggerMock.Object);

            // Act
            var result = controller.GetUrlByCode("invalid");

            // Assert
            Assert.IsType<NotFound>(result);
        }
    }
}
