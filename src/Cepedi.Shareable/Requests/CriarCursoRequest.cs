using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Cepedi.Shareable.Responses;


namespace Cepedi.Shareable.Requests;

public class CriarCursoRequest : IRequest<CriarCursoResponse>
{
    public string Nome { get; set; } = default!;
    public string Descricao { get; set; } = default!;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int ProfessorId { get; set; }
}

/*
public record CriaCursoRequest(
string Nome,
string Descricao,
DateTime DataInicio,
DateTime DataFim,
int ProfessorId;
*/