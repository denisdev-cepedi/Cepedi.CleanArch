using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using Microsoft.EntityFrameworkCore;
using Cepedi.Banco.Pessoa.Dados.Repositorios.Queries;
using Cepedi.Banco.Pessoa.Dominio.Services;
using Cepedi.Compartilhado.Responses;

namespace Cepedi.Banco.Pessoa.Dados.Repositorios;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceExterno _serviceExterno;

    public EnderecoRepository(ApplicationDbContext context, IServiceExterno serviceExterno)
    {
        _context = context;
        _serviceExterno = serviceExterno;
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
        if (endereco == null)
        {
            endereco = await ObterEnderecoPorCepExternoAsync(cep);
        }
        return endereco;
    }

    public async Task<List<EnderecoEntity>> ObterTodosEnderecosAsync()
    {
        var enderecos = await _context.Endereco.ToListAsync();
        return enderecos;
    }

    public async Task<EnderecoEntity> ObterEnderecoPorCepExternoAsync(string cep)
    {
        var response = await _serviceExterno.ObterEnderecoPorCepExternoAsync(cep);

        if (response == null)
        {
            return null;
        }

        var endereco = new EnderecoEntity()
        {
            Cep = response.cep,
            Logradouro = response.logradouro,
            Complemento = response.complemento,
            Bairro = response.bairro,
            Cidade = response.localidade,
            Uf = response.uf,
            Pais = "Brasil",
            Numero = "S/N"
        };

        return endereco;
    }
}
