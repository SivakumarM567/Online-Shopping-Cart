using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Services
{
    public class CartService
    {
        private ICart _cartRepository;
        public CartService(ICart cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public string SaveCart(Cart cart)
        {
            return _cartRepository.SaveCart(cart);
        }
        public string DeleteCart(int CartId)
        {
            return _cartRepository.DeleteCart(CartId);
        }
        public string UpdateCart(Cart cart)
        {
            return _cartRepository.UpdateCart(cart);
        }
        public Cart GetCart(int CartId)
        {
            return _cartRepository.GetCart(CartId);
        }
        public List<Cart> GetAllCart()
        {
            return _cartRepository.GetAllCart();
        }

        public IEnumerable<Cart> GetCartByUserID(int UserId)
        {
            return _cartRepository.GetCartByUserID(UserId);
        }
        public int GetCartId(int UserId)
        {
            return _cartRepository.GetCartId(UserId);
        }
    }
}
