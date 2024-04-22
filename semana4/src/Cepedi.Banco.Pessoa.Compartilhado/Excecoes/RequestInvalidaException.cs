using Cepedi.Banco.Pessoa.Compartilhado.Enums;

namespace Cepedi.Banco.Pessoa.Compartilhado.Excecoes;
public class RequestInvalidaException : ApplicationException
{
    public RequestInvalidaException(IDictionary<string, string[]> erros)
        : base(BancoCentralMensagemErrors.DadosInvalidos.Descricao) =>
        Erros = erros.Select(e => $"{e.Key}: {string.Join(", ", e.Value)}");

    public IEnumerable<string> Erros { get; }
}
