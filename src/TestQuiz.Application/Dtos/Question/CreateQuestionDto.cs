using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Answer;

namespace TestQuiz.Application.Dtos.Question
{
    public class CreateQuestionDto
    {
        public string Title { get; set; }

        public int TestId { get; set; }

        public List<CreateAnswerDto> Answers { get; set; } = new();
    }
}
