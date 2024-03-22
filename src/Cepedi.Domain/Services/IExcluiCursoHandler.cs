using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Services;
public interface IExcluiCursoHandler
{
    Task<int> ExcluiCursoAsync(int idCurso);
}
