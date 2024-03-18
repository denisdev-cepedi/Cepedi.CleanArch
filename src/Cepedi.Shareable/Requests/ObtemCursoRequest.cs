using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public record ObtemCursoRequest(int idCurso) : IRequest<ObtemCursoResponse>;
