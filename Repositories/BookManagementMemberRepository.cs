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
    public class BookManagementMemberRepository : IBookManagementMemberRepository
    {
        public async Task<ICollection<BookManagementMember>> GetAllMember()
        {
            return await BookManagementMemberDAO.Instance.GetAllMember();
        }
        public async Task<BookManagementMember> GetMemberById(int id)
        {
            return await BookManagementMemberDAO.Instance.GetMemberById(id);
        }
        public async Task Create(BookManagementMember employee)
        {
            await BookManagementMemberDAO.Instance.Create(employee);
        }
        public async Task Update(BookManagementMember employee)
        {
            await BookManagementMemberDAO.Instance.Update(employee);
        }
        public async Task Delete(int id)
        {
            await BookManagementMemberDAO.Instance.Delete(id);
        }
        public async Task<BookManagementMember> GetMemberByEmail(string email)
        {
           return await BookManagementMemberDAO.Instance.GetMemberByEmail(email);
        }
        public async Task<ICollection<BookManagementMember>> Search(string query)
        {
            return await BookManagementMemberDAO.Instance.Search(query);
        }
    }
}
