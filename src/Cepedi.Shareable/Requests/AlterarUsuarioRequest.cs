using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public class AlterarUsuarioRequest : IRequest<AlterarUsuarioResponse>
{
    private string _v1;
    private string _v2;
    private DateTime _now1;
    private DateTime _now2;
    private int _v3;
    private string _v4;

    public AlterarUsuarioRequest()
    {
    }

    public AlterarUsuarioRequest(string v1, string v2, DateTime now1, DateTime now2, int v3, int v, string v4)
    {
        _v1 = v1;
        _v2 = v2;
        _now1 = now1;
        _now2 = now2;
        _v3 = v3;
        _v4 = v4;
    }

    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; } = default!;
    public string Celular { get; set; } = default!;
    public bool CelularValidado { get; set; }
    public string Email { get; set; } = default!;
}
