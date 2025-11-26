using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos;
using TestQuiz.Application.Interfaces;
using TestQuiz.Domain.Entities;
using TestQuiz.Domain.Exceptions;
using TestQuiz.Domain.Interfaces;

namespace TestQuiz.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository,
            IJwtProvider jwtProvider,
            IPasswordHasher passwordHasher,
            ILogger<AuthService> logger) 
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var trimmedName = loginDto.UserName.Trim();

            var user = await _userRepository.GetByName(trimmedName);

            if (user == null)
            {
                _logger.LogWarning("Log failed. User not found. UserName={UserName}", loginDto.UserName);

                throw new UnauthorizedAccessException("Invalid username or password.");
            }
                
            bool isPasswordValid = _passwordHasher.Verify(loginDto.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                _logger.LogWarning("Log failed. Invalid password. UserId={UserId}", user.Id);

                throw new UnauthorizedAccessException("Invalid username or password.");
            }
                
            _logger.LogInformation("User logged in. UserId={UserId}", user.Id);

            return _jwtProvider.GenerateToken(user);
        }


        public async Task Register(RegisterDto registerDto)
        {
            var isExists = await _userRepository.ExistByName(registerDto.UserName.Trim());

            if (isExists)
            {
                _logger.LogWarning("User registration failed. User already exists. UserName={UserName}", registerDto.UserName);
                throw new AlreadyExistsException(registerDto.UserName);
            }
                
            var hash = _passwordHasher.HashPassword(registerDto.Password);

            var user = new User
            {
                Name = registerDto.UserName.Trim(),
                Email = registerDto.Email,
                PasswordHash = hash
            };

            await _userRepository.Add(user);

            _logger.LogInformation("User created. UserId={UserId}", user.Id);
        }
    }
}
