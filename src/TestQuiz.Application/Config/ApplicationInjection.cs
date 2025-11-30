using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Dtos.Answer;
using TestQuiz.Application.Dtos.Question;
using TestQuiz.Application.Dtos.Test;
using TestQuiz.Application.Interfaces;
using TestQuiz.Application.Services;
using TestQuiz.Domain.Entities;

namespace TestQuiz.Application.Config
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IExamService, ExamService>();

            services.AddDistributedMemoryCache();

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Question, QuestionDto>();
                cfg.CreateMap<CreateQuestionDto, Question>();

                cfg.CreateMap<CreateAnswerDto, Answer>();
                cfg.CreateMap<Answer, AnswerDto>();

                cfg.CreateMap<CreateTestDto, Test>();
                cfg.CreateMap<Test, TestDto>()
                    .ForMember(dest => dest.QuestionsCount, opt => opt.MapFrom(src => src.Questions.Count()));

            });

            return services;
        }
    }
}
