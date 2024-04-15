using Cepedi.Compartilhado.Exceptions;

namespace Cepedi.Banco.Pessoa.Compartilhado.Exceptions;
public class AplicacaoExcecao : Exception
{
    public AplicacaoExcecao(ResultadoErro erro)
     : base(erro.Descricao) => ResponseErro = erro;

    public ResultadoErro ResponseErro { get; set; }
}
