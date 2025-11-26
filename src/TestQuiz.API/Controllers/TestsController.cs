using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestQuiz.Application.Dtos.Test;
using TestQuiz.Application.Interfaces;

namespace TestQuiz.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _service;

        public TestsController(ITestService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<TestDto>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestDto>> GetById([FromRoute] int id)
        {
            return await _service.GetById(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTestDto testCreateDto)
        {
            await _service.Add(testCreateDto);
            return StatusCode(201, "Test added successfully");
        }
    }
}
