﻿using BusnessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookManagementMemberDAO : SingletonBase<BookManagementMemberDAO>
    {
        public async Task<ICollection<BookManagementMember>> GetAllMember()
        {
            using (var context = new BookStoreContext())
            {
                return await context.BookManagementMembers.ToListAsync();
            }
        }
        public async Task<BookManagementMember> GetMemberById(int id)
        {
            return await _context.BookManagementMembers.FirstOrDefaultAsync(t => t.MemberId == id);
        }
        public async Task Create(BookManagementMember employee)
        {
            await _context.BookManagementMembers.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        public async Task Update(BookManagementMember employee)
        {
            var existitem = await GetMemberById(employee.MemberId);
            if (existitem != null)
            {
                _context.Entry(existitem).CurrentValues.SetValues(employee);
            }
            else
            {
                await Create(employee);
            }
            await _context.SaveChangesAsync();  
        }
        public async Task Delete(int id)
        {
            var existitem = await GetMemberById(id);
            if (existitem != null)
            {
                _context.BookManagementMembers.Remove(existitem);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<BookManagementMember> GetMemberByEmail(string email)
        {
            BookManagementMember account = new BookManagementMember();
            return await _context.BookManagementMembers.FirstOrDefaultAsync(t => t.Email == email);
        }
        public async Task<ICollection<BookManagementMember>> Search(string query)
        {
            return await _context.BookManagementMembers.Where(c => c.Email.Contains(query) ||
                                           c.FullName.Contains(query)).ToListAsync();
        }
    }
}
