using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuiz.Application.Dtos.Test
{
    public class CreateTestDto
    {
        [Required(ErrorMessage = "Test title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [MaxLength(30)]
        public string Author { get; set; } = "Anonymous";
    }
}
