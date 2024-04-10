using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Responses;
using MediatR;
using Refit;

namespace Cepedi.Shareable.Requests;
public class CriaCursoRequest : IRequest<CriaCursoResponse>{
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public DateTime DataInicio {get;set;}
    public DateTime DataFim {get;set;}
    public int ProfessorId {get;set;}
    
}
//(string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
