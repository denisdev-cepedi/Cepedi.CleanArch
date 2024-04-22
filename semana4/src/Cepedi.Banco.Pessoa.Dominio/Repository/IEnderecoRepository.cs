using Cepedi.Banco.Pessoa.Dominio.Entidades;

namespace Cepedi.Banco.Pessoa.Dominio.Repository;

public interface IEnderecoRepository
{
    Task<EnderecoEntity> ObterEnderecoAsync(int id);
    Task<EnderecoEntity> ObterEnderecoPorCepAsync(string cep);
    Task<List<EnderecoEntity>> ObterTodosEnderecosAsync();
    Task<EnderecoEntity> CadastrarEnderecoAsync(EnderecoEntity endereco);
    Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco);
    Task<EnderecoEntity> ExcluirEnderecoAsync(EnderecoEntity endereco);
}
