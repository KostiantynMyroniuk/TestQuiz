using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Test;

namespace TestQuiz.Application.Interfaces
{
    public interface ITestService
    {
        Task Add(CreateTestDto testDto);
        Task Delete(int id);
        Task<List<TestDto>> GetAll();
        Task<TestDto> GetById(int id);
    }
}
