using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Cepedi.Banco.Pessoa.Benchmark.Test.Helpers;
public class AppConfigurations
{
    public string ConnectionString { get; }

    public AppConfigurations()
    {
        var configuration = LoadConfiguration();
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private IConfiguration LoadConfiguration()
    {
        var builder = new ConfigurationBuilder()
         .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
         .AddJsonFile("appsettings.json");

        return builder.Build();
    }
}
