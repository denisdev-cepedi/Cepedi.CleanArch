using Cepedi.Banco.Pessoa.Dominio.Entidades;

namespace Cepedi.Banco.Pessoa.Dominio.Repository;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> ObterUsuarioAsync(int id);

    Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario);
}
