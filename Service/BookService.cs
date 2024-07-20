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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService() {
            _bookRepository = new BookRepository();
        }

        public async Task<ICollection<Book>> GetAllBook()
        {
            return await _bookRepository.GetAllBook();
        }
        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }
        public async Task<ICollection<Book>> GetBookByCategoryId(int id)
        {
            return await _bookRepository.GetBookByCategoryId(id);
        }
        public async Task Create(Book book)
        {
            await _bookRepository.Create(book);
        }
        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }
        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
        }
        public async Task<ICollection<Book>> Search(string query)
        {
            return await _bookRepository.Search(query);
        }
    }
}
