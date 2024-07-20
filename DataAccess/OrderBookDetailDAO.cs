using BusnessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderBookDetailDAO : SingletonBase<OrderBookDetailDAO>
    {
        public async Task<ICollection<OrderBookDetail>> GetAllOrderBookDetail()
        {
            return await _context.OrderBookDetails.ToListAsync();
        }
        public async Task<ICollection<OrderBookDetail>> GetAllOrderBookDetailByOrderId(int id)
        {
            return await _context.OrderBookDetails.Where(t => t.OrderBookId== id).Include(t => t.Book).ToListAsync();
        }
        public async Task<OrderBookDetail> GetOrderBookDetailByOrderIdBookid(int orderid, int bookid)
        {
            return await _context.OrderBookDetails.FirstOrDefaultAsync(t => t.OrderBookId == orderid && t.BookId==bookid);
        }
        public async Task Create(OrderBookDetail employee)
        {
            await _context.OrderBookDetails.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        public async Task Update(OrderBookDetail employee)
        {
            var existitem = await GetOrderBookDetailByOrderIdBookid(employee.OrderBookId,employee.BookId);
            if (existitem != null)
            {
                _context.Entry(existitem).CurrentValues.SetValues(employee);
            }
            await _context.SaveChangesAsync();  
        }
        public async Task Delete(int orderid, int bookid)
        {
            var existitem = await GetOrderBookDetailByOrderIdBookid(orderid, bookid);
            if (existitem != null)
            {
                _context.OrderBookDetails.Remove(existitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
