using LutryShop.OrderApi.Models;

namespace LutryShop.OrderApi.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);
    }
}
