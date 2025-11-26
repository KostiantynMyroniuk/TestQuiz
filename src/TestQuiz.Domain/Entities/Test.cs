using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuiz.Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int QuestionsCount { get; set; }
        public string? Author { get; set; }


        List<Question> Questions { get; set; } = new();
    }
}
