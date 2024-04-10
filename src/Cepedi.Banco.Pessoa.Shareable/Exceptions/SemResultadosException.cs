using Cepedi.Banco.Pessoa.Shareable.Enums;

namespace Cepedi.Banco.Pessoa.Shareable.Exceptions;
public class SemResultadosException : ApplicationException
{
    public SemResultadosException() : 
        base(BancoCentralMensagemErrors.SemResultados)
    {
    }
}
