using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public interface IAtualizaCursoHandler
{
    Task<AtualizaCursoResponse> AtualizarCursoAsync(int idCurso, CriaCursoRequest cursoRequest);
}
