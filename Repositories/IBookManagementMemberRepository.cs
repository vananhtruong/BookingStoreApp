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

        Task<BookManagementMember> GetMemberByEmail(string email);
        void UpdateCus(BookManagementMember p);
        Task<ICollection<BookManagementMember>> Search(string query);
    }
}
