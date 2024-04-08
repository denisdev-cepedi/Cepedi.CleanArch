using Cepedi.BancoCentral.Domain;
using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Microsoft.EntityFrameworkCore.Query;

namespace Cepedi.BancoCentral.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuario.Add(usuario);
            
            await _context.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioEntity> AlterarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuario.Update(usuario);
            
            await _context.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioEntity?> ObterUsuarioAsync(int id)
        {
            return _context.Usuario.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
