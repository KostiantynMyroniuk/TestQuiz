using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuiz.Domain.Entities
{
    public class UserExamSession
    {
        public int TestId { get; set; }
        public List<int> QuestionsId { get; set; } = new();
        public int CurrentIndex { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
