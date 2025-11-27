using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Answer;
using TestQuiz.Application.Dtos.Question;
using TestQuiz.Application.Interfaces;
using TestQuiz.Domain.Entities;
using TestQuiz.Domain.Interfaces;

namespace TestQuiz.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository,
            IMapper mapper,
            IApplicationDbContext context)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task Add(CreateQuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            await _questionRepository.Add(question);
        }

        public async Task<List<QuestionDto>> GetAll()
        {
            return await _context.Questions
                                .AsNoTracking()
                                .ProjectTo<QuestionDto>(_mapper.ConfigurationProvider)
                                .ToListAsync();

        }
    }
}
