using Cepedi.Banco.Pessoa.Compartilhado.Enums;

namespace Cepedi.Compartilhado.Exceptions;
public class ResultadoErro
{
    public string Titulo { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public ETipoErro Tipo { get; set; }
}
