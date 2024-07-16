using BusnessObject;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public interface IBookManagementMemberRepository
    {
        Task<ICollection<BookManagementMember>> GetAllMember();
        Task<BookManagementMember> GetMemberById(int id);
        Task Create(BookManagementMember employee);
        Task Update(BookManagementMember employee);
        Task Delete(int id);
    }
}
