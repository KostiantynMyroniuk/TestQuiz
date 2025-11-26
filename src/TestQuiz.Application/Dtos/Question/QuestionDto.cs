using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Answer;

namespace TestQuiz.Application.Dtos.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<AnswerDto> Answers { get; set; } = new();
    }
}
