using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public class CriaCursoRequest : IRequest<CriaCursoResponse>{
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public DateTime DataInicio {get;set;}
    public DateTime DataFim {get;set;}
    public int ProfessorId {get;set;}
}
