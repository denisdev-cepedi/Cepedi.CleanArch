using Cepedi.Shareable.Responses;
using MediatR;
namespace Cepedi.Shareable;

public class CriarCursoRequest : IRequest<CriarCursoResponse>
{
    public string nome { get; set; } = default!;

    public string descricao { get; set; } = default!;
    public DateTime inicio { get; set; }
    public DateTime fim { get; set; }
    public int idProfessor { get; set; }
}