using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Question;

namespace TestQuiz.Application.Interfaces
{
    public interface IQuestionService
    {
        Task Add(CreateQuestionDto questionDto);
        Task<List<QuestionDto>> GetAll();

    }
}
