using BusnessObject;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public interface IBookCategoryRepository
    {
        Task<ICollection<BookCategory>> GetAllBookCategory();
        Task<BookCategory> GetBookCategoryById(int id);
        Task Create(BookCategory employee);
        Task Update(BookCategory employee);
        Task Delete(int id);
        Task<ICollection<BookCategory>> Search(string query);
    }
}
