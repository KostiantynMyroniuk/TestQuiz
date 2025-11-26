using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Domain.Entities;
using TestQuiz.Domain.Interfaces;
using TestQuiz.Infrastructure.Contexts;

namespace TestQuiz.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) => _context = context;
        
        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistByName(string name)
        {
           return await _context.Users
                            .AnyAsync(u => u.Name == name);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByName(string name)
        {
            return await _context.Users
                            .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
