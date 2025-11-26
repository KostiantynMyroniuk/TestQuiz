using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Domain.Entities;

namespace TestQuiz.Domain.Interfaces
{
    public interface IAnswerRepository
    {
        Task Add(Answer answer);
        Task Delete(Answer answer);
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer?> GetById(int id);
    }
}
