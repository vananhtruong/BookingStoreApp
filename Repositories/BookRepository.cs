using BusnessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<ICollection<Book>> GetAllBook()
        {
            return await BookDAO.Instance.GetAllBook();
        }
        public async Task<Book> GetBookById(int id)
        {
            return await BookDAO.Instance.GetBookById(id);
        }
        public async Task<ICollection<Book>> GetBookByCategoryId(int id)
        {
            return await BookDAO.Instance.GetBookByCategoryId(id);
        }
        public async Task Create(Book book)
        {
            await BookDAO.Instance.Create(book);
        }
        public async Task Update(Book book)
        {
            await BookDAO.Instance.Update(book);
        }
        public async Task Delete(int id)
        {
            await BookDAO.Instance.Delete(id);
        }
        public async Task<ICollection<Book>> Search(string query)
        {
            return await BookDAO.Instance.Search(query);
        }
    }
}
