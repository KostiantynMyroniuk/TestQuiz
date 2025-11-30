using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Question;
using TestQuiz.Application.Interfaces;
using TestQuiz.Domain.Entities;
using TestQuiz.Domain.Interfaces;

namespace TestQuiz.Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IQuestionRepository _repository;
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;

        public ExamService(IQuestionRepository repository,
            IDistributedCache cashe,
            IMapper mapper)
        {
            _repository = repository;
            _cache = cashe;
            _mapper = mapper;
        }

        public async Task<Guid> StartSession(int quizId)
        {
            var questionIds = await _repository.GetIdsByTest(quizId);

            Random.Shared.Shuffle(CollectionsMarshal.AsSpan(questionIds));

            var sessionId = Guid.NewGuid();
            var session = new UserExamSession
            {
                TestId = quizId,
                QuestionIds = new Queue<int>(questionIds)
            };

            var json = JsonSerializer.Serialize(session);

            await _cache.SetStringAsync(sessionId.ToString(), json, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            });

            return sessionId;
        }

        public async Task<QuestionDto?> GetNextQuestion(Guid sessionId)
        {
            var json = await _cache.GetStringAsync(sessionId.ToString());

            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("Session not found");
            }

            var session = JsonSerializer.Deserialize<UserExamSession>(json);

            if (session.QuestionIds.Count == 0)
            {
                await _cache.RemoveAsync(sessionId.ToString());
                return null;
            }

            int nextQuestionId = session.QuestionIds.Dequeue();

            var updatedJson = JsonSerializer.Serialize(session);

            await _cache.SetStringAsync(sessionId.ToString(), updatedJson);

            var question = await _repository.GetByIdWithOptions(nextQuestionId);

            return _mapper.Map<QuestionDto>(question);
        }
    }
}
