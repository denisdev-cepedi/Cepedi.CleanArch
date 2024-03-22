namespace Cepedi.Domain.Services;

public interface IDeleteCursoHandler
{
    Task DeleteCursoAsync(int idCurso);
}
