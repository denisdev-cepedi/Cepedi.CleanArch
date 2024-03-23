namespace Cepedi.Domain.Services;

public interface IDeletaCursoHandler
{
    Task<int> DeletaCursoAsync(int id);
}
