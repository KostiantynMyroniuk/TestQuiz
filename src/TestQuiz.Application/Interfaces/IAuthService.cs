using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos;

namespace TestQuiz.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto loginDto);
        Task Register(RegisterDto registerDto);
    }
}
