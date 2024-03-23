using System.Diagnostics.CodeAnalysis;
using Cepedi.Data;
using Cepedi.Data.Repositories;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
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
            services.AddScoped<IObtemTodosCursosHandler, ObtemTodosCursosHandler>();
            services.AddScoped<IObtemCursoHandler, ObtemCursoHandler>();
            services.AddScoped<ICadastraCursoHandler, CadastraCursoHandler>();
            services.AddScoped<IEditaCursoHandler, EditaCursoHandler>();
            services.AddScoped<IDeletaCursoHandler, DeletaCursoHandler>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();

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