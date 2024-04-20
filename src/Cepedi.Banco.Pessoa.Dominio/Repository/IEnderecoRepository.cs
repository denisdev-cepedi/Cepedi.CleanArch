using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;

namespace Cepedi.Banco.Pessoa.Dominio.Repository;

public interface IEnderecoRepository
{
    Task<ObterEnderecoResponse> ObterEndereco(int id);
    Task<ObterTodosEnderecosResponse> ObterTodosEnderecos();
    Task<CadastrarEnderecoResponse> CadastrarEndereco(CadastrarEnderecoRequest request);
    Task<ExcluirEnderecoResponse> ExcluirEndereco(ExcluirEnderecoRequest request);
    Task<AtualizarEnderecoRequest> AtualizarEndereco(AtualizarEnderecoRequest request);
}
