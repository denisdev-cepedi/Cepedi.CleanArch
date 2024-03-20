using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cepedi.Data
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) => 
            await _context.Curso.FirstOrDefaultAsync(curso => curso.Id == idCurso);

        public async Task<IEnumerable<CursoEntity>> ObterTodosCursosAsync() => 
            await _context.Curso.ToListAsync();

        public async Task AdicionarCursoAsync(CursoEntity curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarCursoAsync(CursoEntity curso)
        {
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverCursoAsync(int idCurso)
        {
            var curso = await _context.Curso.FindAsync(idCurso);
            if (curso != null)
            {
                _context.Curso.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
