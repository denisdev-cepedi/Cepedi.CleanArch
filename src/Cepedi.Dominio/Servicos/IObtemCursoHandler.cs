using Cepedi.Compartilhado.Responses;

namespace Cepedi.Dominio
{
    public interface IObtemCursoHandler
    {
        Task<ObtemCursoResponse> ObterCursoAsync(int idCurso);
        Task<IEnumerable<ObtemCursoResponse>> ObterCursosAsync();
    }
}
