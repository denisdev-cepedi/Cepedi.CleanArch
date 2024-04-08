using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Repository
{
    public interface IAlteraCursoHandler
    {
        Task<int> AlterarCursoAsync(AlteraCursoRequest request);
    }
}
