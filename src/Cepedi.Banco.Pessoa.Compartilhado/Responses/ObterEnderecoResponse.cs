namespace Cepedi.Banco.Pessoa.Compartilhado.Responses;

public class ObterEnderecoResponse
{
    public int Id { get; set; }
    public string Cep { get; set; } = default!;
    public string Logradouro { get; set; } = default!;
    public string Complemento { get; set; } = default!;
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public string Uf { get; set; } = default!;
    public string Pais { get; set; } = default!;
    public string Numero { get; set; } = default!;
}
