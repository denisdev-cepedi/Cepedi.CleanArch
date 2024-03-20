using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public record ApagarCursoRequest(int idCurso) : IRequest<ApagarCursoResponse>;
