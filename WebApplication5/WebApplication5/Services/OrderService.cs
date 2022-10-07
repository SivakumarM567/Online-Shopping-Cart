using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Services
{
    public class OrderService
    {
        private IOrder _orderDetailsRepository;
        public OrderService(IOrder orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        public string SaveOrderDetails(Order orderDetails)
        {
            return _orderDetailsRepository.SaveOrderDetails(orderDetails);
        }
        public string DeleteOrderDetails(int OrderId)
        {
            return _orderDetailsRepository.DeleteOrderDetails(OrderId);
        }
        public string UpdateOrderDetails(Order orderDetails)
        {
            return _orderDetailsRepository.UpdateOrderDetails(orderDetails);
        }
        public Order GetOrderDetails(int OrderId)
        {
            return _orderDetailsRepository.GetOrderDetails(OrderId);
        }
        public List<Order> GetAllOrderDetails()
        {
            return _orderDetailsRepository.GetAllOrderDetails();
        }
    }
}
