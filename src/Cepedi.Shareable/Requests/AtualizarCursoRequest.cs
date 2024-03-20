using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public record AtualizarCursoRequest(int id, string nome, string descricao, DateTime dataInicio, DateTime dataFim, int professorId) : IRequest<AtualizarCursoResponse>;
