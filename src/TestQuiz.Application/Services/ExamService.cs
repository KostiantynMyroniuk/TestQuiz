using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Question;
using TestQuiz.Application.Interfaces;
using TestQuiz.Domain.Interfaces;

namespace TestQuiz.Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IQuestionRepository _repository;
        private readonly IDistributedCache _cache;

        public ExamService(IQuestionRepository repository,
            IDistributedCache cashe)
        {
            _repository = repository;
            _cache = cashe;
        }

        public async Task<QuestionDto?> GetNextQuestion(int userId, int testId)
        {
            string cacheKey = $"exam_session:{userId}:{testId}";

            string? sessionJson = await _cache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(sessionJson))
            { 
                                                
            }

            return new QuestionDto();
        }
    }
}
