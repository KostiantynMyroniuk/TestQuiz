using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Domain.Entities;

namespace TestQuiz.Domain.Interfaces
{
    public interface ITestRepository
    {
        Task Add(Test test);
        Task Delete(Test test);
        Task<IEnumerable<Test>> GetAll();
        Task<Test?> GetById(int id);
        Task<bool> IsTitleExists(string title);
        IQueryable<Test> GetQueryable();
    }
}
