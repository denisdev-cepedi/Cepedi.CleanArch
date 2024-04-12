using MediatR;
using Cepedi.Shareable.Responses;
using OperationResult;

namespace Cepedi.Shareable.Requests;

public class CriaCursoRequest : IRequest<Result<CriaCursoResponse>> {
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int ProfessorId { get; set; }
}
