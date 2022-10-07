using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface ICart
    {
        public string SaveCart(Cart cart);
        public string UpdateCart(Cart cart);
        public string DeleteCart(int CartId);
        Cart GetCart(int CartId);
        List<Cart> GetAllCart();
        public IEnumerable<Cart> GetCartByUserID(int UserId);
        public int GetCartId(int UserId);
    }
}
