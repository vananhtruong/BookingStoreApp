using BusnessObject;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public interface IBookCategoryService
    {
        Task<ICollection<BookCategory>> GetAllBookCategory();
        Task<BookCategory> GetBookCategoryById(int id);
        Task Create(BookCategory employee);
        Task Update(BookCategory employee);
        Task Delete(int id);
        Task<ICollection<BookCategory>> Search(string query);
    }
}
