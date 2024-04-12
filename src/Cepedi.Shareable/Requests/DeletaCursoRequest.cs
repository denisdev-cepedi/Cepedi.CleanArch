using Cepedi.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Shareable;

public class DeletaCursoRequest : IRequest<Result<DeletaCursoResponse>>
{
    public int IdCurso { get; set; }
}
