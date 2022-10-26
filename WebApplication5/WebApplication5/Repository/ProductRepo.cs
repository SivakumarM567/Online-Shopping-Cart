using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class ProductRepo : IProduct
    {
        private ShoppingCartDbContext _ShoppingCartDb;

        #region ProductRepo
        /// <summary>
        /// ProductRepo Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public ProductRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        #endregion


        #region DeleteProduct
        /// <summary>
        /// Method for deleting product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public string DeleteProduct(int ProductId)
        {
            string msg = "";
            Product delete = _ShoppingCartDb.Product.Find(ProductId);
            try
            {
                if (delete != null)
                {
                    _ShoppingCartDb.Product.Remove(delete);
                    _ShoppingCartDb.SaveChanges();
                    msg = "Deleted";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        #endregion


        #region GetAllProduct
        /// <summary>
        /// Method to get all the product
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProduct()
        {

            List<Product> product = _ShoppingCartDb.Product.ToList();
            return product;
        }
        #endregion


        #region GetProduct
        /// <summary>
        /// Method to get product by id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Product GetProduct(int ProductId)
        {
            try
            {
                Product product = _ShoppingCartDb.Product.Find(ProductId);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetProductByName
        /// <summary>
        /// Method to get product by id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Product GetProductByName(string ProductName)
        {
            Product product = null;
            try
            {
                product = _ShoppingCartDb.Product.FirstOrDefault(q => q.ProductName == ProductName);
                
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }
        #endregion


        #region SaveProduct
        /// <summary>
        /// Method to save the product details
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public string SaveProduct(Product Product)
        {
            try
            {
                _ShoppingCartDb.Product.Add(Product);
                _ShoppingCartDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Saved";
        }
        #endregion


        #region UpdateProduct
        /// <summary>
        /// Method to Update product details
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public string UpdateProduct(Product Product)
        {
            try
            {
                _ShoppingCartDb.Entry(Product).State = EntityState.Modified;
                _ShoppingCartDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Updated";
        }
        #endregion
    }
}
