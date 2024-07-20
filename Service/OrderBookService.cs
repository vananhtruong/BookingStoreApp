using BusnessObject;
using DataAccess;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderBookService : IOrderBookService
    {
        private readonly IOrderBookRepository _bookRepository;
        public OrderBookService() {
            _bookRepository = new OrderBookRepository();
        }

        public async Task<ICollection<OrderBook>> GetAllOrderBook()
        {
            return await _bookRepository.GetAllOrderBook();
        }
        public async Task<OrderBook> GetOrderBookById(int id)
        {
            return await _bookRepository.GetOrderBookById(id);
        }
        public async Task<ICollection<OrderBook>> GetOrderBookByMemberId(int id)
        {
            return await _bookRepository.GetOrderBookByMemberId(id);
        }
        public async Task Create(OrderBook employee)
        {
            await _bookRepository.Create(employee);
        }
        public async Task Update(OrderBook employee)
        {
            await _bookRepository.Update(employee);
        }
        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
        }
        public async Task AddOrder(OrderBook order, List<OrderBookDetail> detail)
        {
            await _bookRepository.AddOrder(order, detail);
        }
    }
}
