using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface IOrder
    {
        public string SaveOrderDetails(Order orderDetails);
        public string UpdateOrderDetails(Order orderDetails);
        public string DeleteOrderDetails(int OrderId);
        Order GetOrderDetails(int OrderId);
        List<Order> GetAllOrderDetails();
    }
}
