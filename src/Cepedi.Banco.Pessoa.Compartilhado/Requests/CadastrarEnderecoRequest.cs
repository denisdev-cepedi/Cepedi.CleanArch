using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Compartilhado.Requests;

public class CadastrarEnderecoRequest : IRequest<Result<CadastrarEnderecoResponse>>
{
    public string Cep { get; set; } = default!;
    public string Logradouro { get; set; } = default!;
    public string Complemento { get; set; } = default!;
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public string Uf { get; set; } = default!;
    public string Pais { get; set; } = default!;
    public string Numero { get; set; } = default!;
    public int IdPessoa { get; set; }
}
