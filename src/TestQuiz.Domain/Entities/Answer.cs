using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuiz.Domain.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
