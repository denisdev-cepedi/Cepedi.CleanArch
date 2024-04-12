using System.Diagnostics.CodeAnalysis;
using Cepedi.Data;
using Cepedi.Data.Repositories;
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

            services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));            
            //services.AddHttpContextAccessor();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}
