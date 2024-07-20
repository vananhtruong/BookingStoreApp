using BusnessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderBookRepository : IOrderBookRepository
    {
        public async Task<ICollection<OrderBook>> GetAllOrderBook()
        {
            return await OrderBookDAO.Instance.GetAllOrderBook();
        }
        public async Task<OrderBook> GetOrderBookById(int id)
        {
            return await OrderBookDAO.Instance.GetOrderBookById(id);
        }
        public async Task<ICollection<OrderBook>> GetOrderBookByMemberId(int id)
        {
            return await OrderBookDAO.Instance.GetOrderBookByMemberId(id);
        }
        public async Task Create(OrderBook employee)
        {
            await OrderBookDAO.Instance.Create( employee);
        }
        public async Task Update(OrderBook employee)
        {
            await OrderBookDAO.Instance.Update(employee);
        }
        public async Task Delete(int id)
        {
            await OrderBookDAO.Instance.Delete(id);
        }
        public async Task AddOrder(OrderBook order, List<OrderBookDetail> detail)
        {
            await OrderBookDAO.Instance.AddOrder(order, detail);
        }
    }
}
