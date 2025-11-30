using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Domain.Entities;

namespace TestQuiz.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task Add(Question question);
        Task Delete(Question question);
        Task<List<int>> GetIdsByTest(int quizId);
        Task<Question?> GetById(int id);
        Task<Question?> GetByIdWithOptions(int id);
    }
}
