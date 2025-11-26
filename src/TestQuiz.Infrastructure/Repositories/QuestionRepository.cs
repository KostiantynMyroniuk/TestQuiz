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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Question question)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _context.Questions
                                .Include(q => q.Answers)
                                .ToListAsync();
        }

        public async Task<Question?> GetById(int id)
        {
            return await _context.Questions.FindAsync(id);
        }
    }
}
