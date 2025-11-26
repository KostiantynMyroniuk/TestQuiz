using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Domain.Entities;

namespace TestQuiz.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
