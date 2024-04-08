using Cepedi.BancoCentral.IoC;

namespace Cepedi.BancoCentral.WebApi;
public static class InitializeDatabaseApplication
{
    public static async Task InitialiseDatabaseAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}
