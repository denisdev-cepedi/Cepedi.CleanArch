using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Repository
{
    public interface ICriaCursoHandler
    {
        Task<int> CriarCursoAsync(CriaCursoRequest request);
    }
}
