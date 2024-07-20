using BusnessObject;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public interface IOrderBookDetailRepository
    {
        Task<ICollection<OrderBookDetail>> GetAllOrderBookDetail();
        Task<OrderBookDetail> GetOrderBookDetailByOrderIdBookid(int orderid, int bookid);
        Task Create(OrderBookDetail employee);
        Task Update(OrderBookDetail employee);
        Task Delete(int orderid, int bookid);
        Task<ICollection<OrderBookDetail>> GetAllOrderBookDetailByOrderId(int id);
    }
}
