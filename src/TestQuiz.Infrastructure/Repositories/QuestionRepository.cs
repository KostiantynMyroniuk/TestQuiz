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

        public async Task<Question?> GetById(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question?> GetByIdWithOptions(int id)
        {
            return await _context.Questions
                                    .AsNoTracking()
                                    .Include(q => q.Answers)
                                    .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<int>> GetIdsByTest(int quizId)
        {
            return await _context.Questions
                            .Where(t => t.TestId == quizId)
                            .Select(q => q.Id)
                            .ToListAsync();
        }
    }
}
