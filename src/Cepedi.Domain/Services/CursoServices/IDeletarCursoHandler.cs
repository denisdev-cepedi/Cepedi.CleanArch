using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Repository;

public interface IDeletarCursoHandler
{
    Task<int> DeletarCursoAsync (int idCurso);
}
