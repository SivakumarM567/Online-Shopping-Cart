using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface IProduct
    {
        public string SaveProduct(Product Product);
        public string UpdateProduct(Product Product);
        public string DeleteProduct(int ProductId);
        Product GetProduct(int ProductId);
        List<Product> GetAllProduct();
    }
}
