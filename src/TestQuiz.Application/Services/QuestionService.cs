using AutoMapper;
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
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task Add(CreateQuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            await _questionRepository.Add(question);
        }

        public async Task<List<QuestionDto>> GetAll()
        {
            var questions = await _questionRepository.GetAll();

            return _mapper.Map<List<QuestionDto>>(questions);
        }
    }
}
