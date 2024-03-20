using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Data.Repositories;
using Cepedi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Cepedi.IoC
{
    [ExcludeFromCodeCoverage]
    public static class AppServiceCollectionExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureHandlersApp();

            ConfigureDbContext(services, configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new AutoMapping()));
            services.AddSingleton(mappingConfig.CreateMapper());

            //services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                //options.UseSqlServer(connectionString);
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}
