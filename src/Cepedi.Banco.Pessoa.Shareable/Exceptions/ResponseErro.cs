using Cepedi.Banco.Pessoa.Shareable.Enums;

namespace Cepedi.Shareable.Exceptions;
public class ResponseErro
{
    public string Titulo { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public ETipoErro Tipo { get; set; }
}
