using Cepedi.Shareable.Requests;

namespace Cepedi.BancoCentral.Domain.Repository
{
    public interface ICriaCursoHandler
    {
         Task<int> CriarCursoAsync(CriaCursoRequest request);
    }
}
