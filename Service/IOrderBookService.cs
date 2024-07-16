using BusnessObject;

namespace Service
{
    public interface IOrderBookService
    {
        Task<ICollection<OrderBook>> GetAllOrderBook();
        Task<OrderBook> GetOrderBookById(int id);
        Task<ICollection<OrderBook>> GetOrderBookByMemberId(int id);
        Task Create(OrderBook employee);
        Task Update(OrderBook employee);
        Task Delete(int id);
    }
}
