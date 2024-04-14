using Cepedi.Compartilhado.Requests;

namespace Cepedi.Dominio.Repository
{
    public interface ICriaCursoHandler
    {
         Task<int> CriarCursoAsync(CriaCursoRequest request);
    }
}
