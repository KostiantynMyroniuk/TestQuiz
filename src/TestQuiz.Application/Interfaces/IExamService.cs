using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Question;

namespace TestQuiz.Application.Interfaces
{
    public interface IExamService
    {
        Task<QuestionDto?> GetNextQuestion(Guid testId);
        Task<Guid> StartSession(int quizId);
    }
}
