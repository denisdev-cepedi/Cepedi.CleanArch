using Cepedi.Banco.Pessoa.Compartilhado.Enums;

namespace Cepedi.Banco.Pessoa.Compartilhado.Exceptions;
public class SemResultadosExcecao : AplicacaoExcecao
{
    public SemResultadosExcecao() : 
        base(BancoCentralMensagemErrors.SemResultados)
    {
    }
}
