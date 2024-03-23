using System.Diagnostics.CodeAnalysis;
using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Shareable.Requests;
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
            services.AddScoped<IAlteraCursoHandler, AlteraCursoHandler>();
            services.AddScoped<IExcluirCursoHandler, ExcluirCursoHandler>();
            services.AddScoped<ICriarCursoHandler, CriarCursoHandler>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}
