using Cepedi.Compartilhado.Exceptions;

namespace Cepedi.Banco.Pessoa.Compartilhado.Enums;
public class BancoCentralMensagemErrors
{
    public static readonly ResponseErro Generico = new()
    {
        Titulo = "Ops ocorreu um erro no nosso sistema",
        Descricao = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static readonly ResponseErro SemResultados = new()
    {
        Titulo = "Sua busca não obteve resultados",
        Descricao = "Tente buscar novamente",
        Tipo = ETipoErro.Alerta
    };

    public static ResponseErro ErroGravacaoUsuario = new()
    {
        Titulo = "Ocorreu um erro na gravação",
        Descricao = "Ocorreu um erro na gravação do usuário. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };
}
