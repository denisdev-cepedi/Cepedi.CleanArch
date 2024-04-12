using Cepedi.Shareable.Enums;

namespace Cepedi.Shareable.Exceptions;

public class ResponseError
{
    public string Titulo { get; set; } = default!;
    public string Descricao { get; set; } = default!;
    public ETipoErro Tipo { get; set; }
}
