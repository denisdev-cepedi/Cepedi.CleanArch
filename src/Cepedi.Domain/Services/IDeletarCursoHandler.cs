using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public interface IDeletarCursoHandler
{
    Task<int> DeletarCursoAsync(int request);
}
