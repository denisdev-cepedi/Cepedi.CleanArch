using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Repository;

namespace Cepedi.Banco.Pessoa.Dados.Repositorios;

public class EnderecoRepository : IEnderecoRepository
{
    public Task<AtualizarEnderecoRequest> AtualizarEndereco(AtualizarEnderecoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CadastrarEnderecoResponse> CadastrarEndereco(CadastrarEnderecoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ExcluirEnderecoResponse> ExcluirEndereco(ExcluirEnderecoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ObterEnderecoResponse> ObterEndereco(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ObterTodosEnderecosResponse> ObterTodosEnderecos()
    {
        throw new NotImplementedException();
    }
}
