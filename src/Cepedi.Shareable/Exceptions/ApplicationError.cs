namespace Cepedi.Shareable.Exceptions;

public class ApplicationException : Exception
{
    public ApplicationException(ResponseError erro)
     : base(erro.Descricao) => ResponseErro = erro;

    public ResponseError ResponseErro { get; set; }
}
