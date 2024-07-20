using BusnessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderBookDetailService : IOrderBookDetailService
    {
        private readonly IOrderBookDetailRepository _bookRepository;
        public OrderBookDetailService() {
            _bookRepository = new OrderBookDetailRepository();
        }

        public async Task<ICollection<OrderBookDetail>> GetAllOrderBookDetail()
        {
            return await _bookRepository.GetAllOrderBookDetail();
        }
        public async Task<OrderBookDetail> GetOrderBookDetailByOrderIdBookid(int orderid, int bookid)
        {
            return await _bookRepository.GetOrderBookDetailByOrderIdBookid(orderid, bookid);
        }
        public async Task Create(OrderBookDetail employee)
        {
            await _bookRepository.Create(employee);
        }
        public async Task Update(OrderBookDetail employee)
        {
            await _bookRepository.Update(employee);
        }
        public async Task Delete(int orderid, int bookid)
        {
            await _bookRepository.Delete(orderid, bookid);
        }
        public async Task<ICollection<OrderBookDetail>> GetAllOrderBookDetailByOrderId(int id)
        {
            return await _bookRepository.GetAllOrderBookDetailByOrderId(id);
        }
    }
}
