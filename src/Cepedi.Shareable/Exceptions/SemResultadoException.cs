using Cepedi.Shareable.Enums;

namespace Cepedi.Shareable.Exceptions;

public class SemResultadosException : ApplicationException
{
    public SemResultadosException() : 
        base(CepediMensagemError.SemResultados)
    {
    }
}
