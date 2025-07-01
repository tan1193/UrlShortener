using UrlShortener.Interface;
using UrlShortener.Model;

namespace UrlShortener.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string GetProductName(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            return product.Name ?? "Unknown Product";
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.GetProductById(productId);
        }
    }
}
