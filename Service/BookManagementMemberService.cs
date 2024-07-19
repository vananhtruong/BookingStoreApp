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
    public class BookManagementMemberService : IBookManagementMemberService
    {
        private readonly IBookManagementMemberRepository _bookRepository;
        public BookManagementMemberService() {
            _bookRepository = new BookManagementMemberRepository();
        }

        public async Task<ICollection<BookManagementMember>> GetAllMember()
        {
            return await _bookRepository.GetAllMember();
        }
        public async Task<BookManagementMember> GetMemberById(int id)
        {
            return await _bookRepository.GetMemberById(id);
        }
        public async Task Create(BookManagementMember employee)
        {
            await _bookRepository.Create(employee);
        }
        public async Task Update(BookManagementMember employee)
        {
            await _bookRepository.Update(employee);
        }
        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
        }
        public async Task<BookManagementMember> GetMemberByEmail(string email)
        {
            return await _bookRepository.GetMemberByEmail(email);
        }
        public void UpdateCus(BookManagementMember p)
        {
            BookManagementMemberDAO.UpdateCus(p);
        }
    }
}
