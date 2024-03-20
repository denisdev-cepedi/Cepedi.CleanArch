using System.Diagnostics.CodeAnalysis;
using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cepedi.IoC
{
    [ExcludeFromCodeCoverage]
    public static class AppServiceCollectionExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
            
            services.AddScoped<IObtemCursoHandler, ObtemCursoHandler>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICriaCursoHandler, CriaCursoHandler>();
            services.AddScoped<IAlteraCursoHandler, AlteraCursoHandler>();
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
