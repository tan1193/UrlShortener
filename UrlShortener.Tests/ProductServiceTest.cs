using Moq;
using UrlShortener.Interface;
using UrlShortener.Services;
using UrlShortener.Model;
using Xunit.Sdk;

namespace UrlShortener.Tests
{
    public class ProductServiceTest
    {
        [Fact]
        public void GetProductName_ReturnProductName_WhenProductExits()
        {
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(x => x.GetProductById(1)).Returns(new Product { Id = 1, Name = "Test Product" });

            var productService = new ProductService(mockRepository.Object);
            var result = productService.GetProductName(1);

            Assert.Equal("Test Product", result);
        }

        [Fact]
        public void GetProductName_ThrowException_WhenRepositoryThrow() 
        {
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(x => x.GetProductById(It.IsAny<int>()))
                                    .Throws(new Exception("Database error"));

            var productService = new ProductService(mockRepository.Object);

            Assert.Throws<Exception>(() => productService.GetProductName(42));
        }

    }
}
