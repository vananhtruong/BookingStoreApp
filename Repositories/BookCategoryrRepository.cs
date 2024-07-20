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
    public class BookCategoryRepository : IBookCategoryRepository
    {
        public async Task<ICollection<BookCategory>> GetAllBookCategory()
        {
            return await BookCategoryDAO.Instance.GetAllBookCategory();
        }
        public async Task<BookCategory> GetBookCategoryById(int id)
        {
            return await BookCategoryDAO.Instance.GetBookCategoryById(id);
        }
        public async Task Create(BookCategory employee)
        {
            await BookCategoryDAO.Instance.Create(employee);
        }
        public async Task Update(BookCategory employee)
        {
            await BookCategoryDAO.Instance.Update(employee);
        }
        public async Task Delete(int id)
        {
            await BookCategoryDAO.Instance.Delete(id);
        }
        public async Task<ICollection<BookCategory>> Search(string query)
        {
            return await BookCategoryDAO.Instance.Search(query);
        }
    }
}
