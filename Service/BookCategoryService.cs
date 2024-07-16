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
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookRepository;
        public BookCategoryService() {
            _bookRepository = new BookCategoryRepository();
        }

        public async Task<ICollection<BookCategory>> GetAllBookCategory()
        {
            return await _bookRepository.GetAllBookCategory();
        }
        public async Task<BookCategory> GetBookCategoryById(int id)
        {
            return await _bookRepository.GetBookCategoryById(id);
        }
        public async Task Create(BookCategory employee)
        {
            await _bookRepository.Create(employee);
        }
        public async Task Update(BookCategory employee)
        {
            await _bookRepository.Update(employee);
        }
        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
        }
    }
}
