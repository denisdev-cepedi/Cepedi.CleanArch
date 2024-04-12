using MediatR;
using OperationResult;

namespace Cepedi.Shareable.Requests;

public class AtualizaCursoRequest : IRequest<Result<AtualizaCursoResponse>> {
    public int IdCurso { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int ProfessorId { get; set; }
}