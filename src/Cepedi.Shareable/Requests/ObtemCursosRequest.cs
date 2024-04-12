using Cepedi.Shareable.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Shareable.Requests;

public class ObtemCursosRequest : IRequest<Result<ObtemCursosResponse>>
{
}
