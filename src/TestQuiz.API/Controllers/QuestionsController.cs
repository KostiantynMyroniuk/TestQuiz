using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestQuiz.Application.Dtos.Question;
using TestQuiz.Application.Interfaces;

namespace TestQuiz.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateQuestionDto createDto)
        {
            await _service.Add(createDto);

            return StatusCode(201, "Question created successfully");
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var questions = await _service.GetAll();

            return Ok(questions);
        }
    }
}
