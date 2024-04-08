using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Responses;
using MediatR;
namespace Cepedi.Shareable.Requests;

 public class CriaCursoRequest : IRequest<CriaCursoResponse>{
    public string Nome { get; set; }
    public string?  Descricao { get; set;}
    public DateTime DataInicio { get;}
    public DateTime DataFim { get;}
    public int ProfessorId { get;}
 }