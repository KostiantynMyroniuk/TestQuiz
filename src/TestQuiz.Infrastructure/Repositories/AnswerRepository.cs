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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public AnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Answer answer)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer?> GetById(int id)
        {
            return await _context.Answers.FindAsync(id);
        }
    }
}
