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
    public class OrderBookDetailRepository : IOrderBookDetailRepository
    {
        public async Task<ICollection<OrderBookDetail>> GetAllOrderBookDetail()
        {
            return await OrderBookDetailDAO.Instance.GetAllOrderBookDetail();
        }
        public async Task<OrderBookDetail> GetOrderBookDetailByOrderIdBookid(int orderid, int bookid)
        {
            return  await OrderBookDetailDAO.Instance.GetOrderBookDetailByOrderIdBookid(orderid,bookid);
        }
        public async Task Create(OrderBookDetail employee)
        {
            await OrderBookDetailDAO.Instance.Create(employee);
        }
        public async Task Update(OrderBookDetail employee)
        {
            await OrderBookDetailDAO.Instance.Update(employee);
        }
        public async Task Delete(int orderid, int bookid)
        {
            await OrderBookDetailDAO.Instance.Delete(orderid,bookid);
        }
        public async Task<ICollection<OrderBookDetail>> GetAllOrderBookDetailByOrderId(int id)
        {
            return await OrderBookDetailDAO.Instance.GetAllOrderBookDetailByOrderId(id);
        }
    }
}
