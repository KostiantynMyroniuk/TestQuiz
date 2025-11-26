using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuiz.Application.Dtos.Test
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int QuestionsCount { get; set; }
        public string Author { get; set; } = null!;
    }
}
