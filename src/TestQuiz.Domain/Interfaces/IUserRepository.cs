using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Domain.Entities;

namespace TestQuiz.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<bool> ExistByName(string name);
        Task<User?> GetById(int id);
        Task<User?> GetByName(string name);
    }
}
