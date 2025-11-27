using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestQuiz.Application.Interfaces;
using TestQuiz.Domain.Interfaces;
using TestQuiz.Infrastructure.Authentication;
using TestQuiz.Infrastructure.Contexts;
using TestQuiz.Infrastructure.Repositories;

namespace TestQuiz.Infrastructure.Config
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddScoped<ITestRepository, TestRepository>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();

            return services;
        }
    }
}
