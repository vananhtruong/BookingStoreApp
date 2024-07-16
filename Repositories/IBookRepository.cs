﻿using BusnessObject;

namespace Repositories
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetAllBook();
        Task<Book> GetBookById(int id);
        Task<ICollection<Book>> GetBookByCategoryId(int id);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(int id);
    }
}