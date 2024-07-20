using BusnessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderBookDAO : SingletonBase<OrderBookDAO>
    {
        public async Task<ICollection<OrderBook>> GetAllOrderBook()
        {
            return await _context.OrderBooks.Include(t => t.Member).ToListAsync();
        }
        public async Task<OrderBook> GetOrderBookById(int id)
        {
            return await _context.OrderBooks.FirstOrDefaultAsync(t => t.OrderBookId == id);
        }
        public async Task<ICollection<OrderBook>> GetOrderBookByMemberId(int id)
        {
            return await _context.OrderBooks.Where(t => t.MemberId == id).ToListAsync();
        }
        public async Task Create(OrderBook employee)
        {
            await _context.OrderBooks.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        public async Task Update(OrderBook employee)
        {
            var existitem = await GetOrderBookById(employee.OrderBookId);
            if (existitem != null)
            {
                _context.Entry(existitem).CurrentValues.SetValues(employee);
            }
            await _context.SaveChangesAsync();  
        }
        public async Task Delete(int id)
        {
            var existitem = await GetOrderBookById(id);
            if (existitem != null)
            {
                _context.OrderBooks.Remove(existitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
