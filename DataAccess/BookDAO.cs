using BusnessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO : SingletonBase<BookDAO>
    {
        public async Task<ICollection<Book>> GetAllBook()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(t => t.BookId == id);
        }
        public async Task<ICollection<Book>> GetBookByCategoryId(int id)
        {
            return await _context.Books.Where(t => t.BookCategoryId == id).ToListAsync();
        }
        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Book book)
        {
            var existitem = await GetBookById(book.BookId);
            if (existitem != null)
            {
                _context.Entry(existitem).CurrentValues.SetValues(book);
            }
            else
            {
                await Create(book);
            }
            await _context.SaveChangesAsync();  
        }
        public async Task Delete(int id)
        {
            var existitem = await GetBookById(id);
            if (existitem != null)
            {
                _context.Books.Remove(existitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
