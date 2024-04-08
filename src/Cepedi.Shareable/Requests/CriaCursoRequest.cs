using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;

public record CriaCursoRequest : IRequest<CriaCursoResponse>
{
    public string Nome { get; set; } = default!;
    public string Descricao { get; set; } = default!;
    public DateTime Inicio { get; set; } = default!;
    public DateTime Fim { get; set; }  = default!;
    public int ProfessorId { get; set; } = default!;
}
