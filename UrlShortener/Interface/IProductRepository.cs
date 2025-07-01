using UrlShortener.Model;

namespace UrlShortener.Interface
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
    }
}
