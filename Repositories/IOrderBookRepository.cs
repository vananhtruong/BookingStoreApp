using BusnessObject;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public interface IOrderBookRepository
    {
        Task<ICollection<OrderBook>> GetAllOrderBook();
        Task<OrderBook> GetOrderBookById(int id);
        Task<ICollection<OrderBook>> GetOrderBookByMemberId(int id);
        Task Create(OrderBook employee);
        Task Update(OrderBook employee);
        Task Delete(int id);
        Task AddOrder(OrderBook order, List<OrderBookDetail> detail);
    }
}
