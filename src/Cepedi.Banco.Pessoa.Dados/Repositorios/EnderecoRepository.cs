using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;

namespace Cepedi.Banco.Pessoa.Dados.Repositorios;

public class EnderecoRepository : IEnderecoRepository
{
    public Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco)
    {
        throw new NotImplementedException();
    }

    public Task<EnderecoEntity> CadastrarEnderecoAsync(EnderecoEntity endereco)
    {
        throw new NotImplementedException();
    }

    public Task<EnderecoEntity> ExcluirEnderecoAsync(EnderecoEntity endereco)
    {
        throw new NotImplementedException();
    }

    public Task<EnderecoEntity> ObterEnderecoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<EnderecoEntity>> ObterTodosEnderecosAsync()
    {
        throw new NotImplementedException();
    }
}
