using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Banco.Pessoa.Dados.Repositorios;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly ApplicationDbContext _context;

    public EnderecoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Update(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> CadastrarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Add(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> ExcluirEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Remove(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> ObterEnderecoAsync(int id)
    {
        var endereco = await _context.Endereco.FirstOrDefaultAsync(endereco => endereco.Id == id);
        return endereco;
    }

    public async Task<EnderecoEntity> ObterEnderecoPorCepAsync(string cep)
    {
        var endereco = await _context.Endereco.FirstOrDefaultAsync(endereco => endereco.Cep == cep);
        return endereco;
    }

    public async Task<List<EnderecoEntity>> ObterTodosEnderecosAsync()
    {
        var enderecos = await _context.Endereco.ToListAsync();
        return enderecos;
    }
}
