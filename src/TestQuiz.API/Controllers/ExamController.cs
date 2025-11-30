using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestQuiz.Application.Interfaces;

namespace TestQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _service;

        public ExamController(IExamService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("{examId}/start")]
        public async Task<IActionResult> StartExam(int examId)
        {
            var sessionId = await _service.StartSession(examId);
            return Ok(sessionId);
        }

        [Authorize]
        [HttpGet("next")]
        public async Task<IActionResult> GetNext([FromQuery] Guid sessionId)
        {
            var question = await _service.GetNextQuestion(sessionId);
            return Ok(question);
        }
    }
}
