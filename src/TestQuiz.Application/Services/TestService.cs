using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Test;
using TestQuiz.Application.Interfaces;
using TestQuiz.Domain.Entities;
using TestQuiz.Domain.Exceptions;
using TestQuiz.Domain.Interfaces;

namespace TestQuiz.Application.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(CreateTestDto testDto)
        {
            var trimmedTitle = testDto.Title.Trim();
            testDto.Title = trimmedTitle;

            var isExists = await _repository.IsTitleExists(trimmedTitle);

            if (isExists)
            {
                throw new AlreadyExistsException(trimmedTitle);
            }

            var test = _mapper.Map<Test>(testDto);

            await _repository.Add(test);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TestDto>> GetAll()
        {
            return await _repository.GetQueryable()
                                .AsNoTracking()
                                .ProjectTo<TestDto>(_mapper.ConfigurationProvider)
                                .ToListAsync();
        }

        public async Task<TestDto> GetById(int id)
        {
            var test =  await _repository.GetQueryable()
                                    .Where(t => t.Id == id)
                                    .ProjectTo<TestDto>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync();
                                    
            if (test == null)
            {
                throw new KeyNotFoundException($"Test with id:{id} not found");
            }

            return test;
        }
    }
}
