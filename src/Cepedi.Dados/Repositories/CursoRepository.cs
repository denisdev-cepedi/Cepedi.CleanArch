using Cepedi.Dominio;
using Cepedi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Dados
{
    public class CursoRepository : ICursoRepository
    {

        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> AlterarCursoAsync(CursoEntity curso)
        {
            _context.Curso.Update(curso);
            return _context.SaveChangesAsync();
        }

        public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) => 
        await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

        public async Task<List<CursoEntity>> ObtemCursosAsync()
        {
           return await _context.Curso.ToListAsync();
        }

        Task<int> ICursoRepository.CriaNovoCursoAsync(CursoEntity curso)
        {
            _context.Curso.Add(curso);
            return _context.SaveChangesAsync();
        }
        
    }
}
