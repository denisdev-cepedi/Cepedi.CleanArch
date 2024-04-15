using Cepedi.Compartilhado.Exceptions;

namespace Cepedi.Banco.Pessoa.Compartilhado.Exceptions;
public class AplicacaoExcecao : Exception
{
    public AplicacaoExcecao(ResponseErro erro)
     : base(erro.Descricao) => ResponseErro = erro;

    public ResponseErro ResponseErro { get; set; }
}
