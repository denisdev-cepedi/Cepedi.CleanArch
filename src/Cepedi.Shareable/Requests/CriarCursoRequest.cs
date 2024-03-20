using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public record CriarCursoRequest(string nome, string descricao, DateTime dataInicio, DateTime dataFim, int professorId) : IRequest<CriarCursoResponse>;
