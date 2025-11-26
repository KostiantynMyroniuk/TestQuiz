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
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Test test)
        {
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Test test)
        {
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Test>> GetAll()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test?> GetById(int id)
        {
            return await _context.Tests.FindAsync(id);
        }

        public async Task<bool> IsTitleExists(string title)
        {
            return await _context.Tests
                                .AnyAsync(x => x.Title == title);
        }
    }
}
