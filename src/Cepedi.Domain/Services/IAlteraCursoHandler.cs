using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain;

public interface IAlteraCursoHandler
{
    Task<int> AlterarCursoAsync(AlteraCursoRequest curso);
}
