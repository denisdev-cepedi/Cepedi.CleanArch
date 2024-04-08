using Cepedi.Shareable.Responses;
using MediatR;
namespace Cepedi.Shareable.Requests;

public class CriarCursoRequest : IRequest<ObtemCursoResponse>
{
    string Nome { get; set; }
    string Descricao { get; set; }
    DateTime DataInicio { get; set; }
    DateTime DataFim { get; set; }
    int ProfessorId { get; set; }
    string telefone { get; set; }
}
