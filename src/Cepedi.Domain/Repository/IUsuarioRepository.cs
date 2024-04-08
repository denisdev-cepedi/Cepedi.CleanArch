using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.BancoCentral.Domain.Repository;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> AlterarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> GetUsuarioById(int UsuarioId);
}
