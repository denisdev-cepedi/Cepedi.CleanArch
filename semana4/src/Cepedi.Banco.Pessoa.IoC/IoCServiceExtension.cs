using System.Diagnostics.CodeAnalysis;
using Cepedi.Banco.Pessoa.Compartilhado;
using Cepedi.Banco.Pessoa.Dados;
using Cepedi.Banco.Pessoa.Dados.Repositorios;
using Cepedi.Banco.Pessoa.Dominio.Pipelines;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cepedi.Banco.Pessoa.IoC
{
    [ExcludeFromCodeCoverage]
    public static class IoCServiceExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            //services.AddMediatR(new[] { typeof(IDomainEntryPoint).Assembly });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExcecaoPipeline<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacaoComportamento<,>));

            ConfigurarFluentValidation(services);

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            //services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }
        private static void ConfigurarFluentValidation(IServiceCollection services)
        {
            var abstractValidator = typeof(AbstractValidator<>);
            var validadores = typeof(QualquerCoisa)
                .Assembly
                .DefinedTypes
                .Where(type => type.BaseType?.IsGenericType is true &&
                type.BaseType.GetGenericTypeDefinition() ==
                abstractValidator)
                .Select(Activator.CreateInstance)
                .ToArray();

            foreach (var validator in validadores)
            {
                services.AddSingleton(validator!.GetType().BaseType!, validator);
            }
        }



        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}
