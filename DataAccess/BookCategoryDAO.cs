using BusnessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookCategoryDAO : SingletonBase<BookCategoryDAO>
    {
        public async Task<ICollection<BookCategory>> GetAllBookCategory()
        {
            return await _context.BookCategories.ToListAsync();
        }
        public async Task<BookCategory> GetBookCategoryById(int id)
        {
            return await _context.BookCategories.FirstOrDefaultAsync(t => t.BookCategoryId == id);
        }
        public async Task Create(BookCategory employee)
        {
            await _context.BookCategories.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        public async Task Update(BookCategory employee)
        {
            var existitem = await GetBookCategoryById(employee.BookCategoryId);
            if (existitem != null)
            {
                _context.Entry(existitem).CurrentValues.SetValues(employee);
            }
            await _context.SaveChangesAsync();  
        }
        public async Task Delete(int id)
        {
            var existitem = await GetBookCategoryById(id);
            if (existitem != null)
            {
                _context.BookCategories.Remove(existitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
