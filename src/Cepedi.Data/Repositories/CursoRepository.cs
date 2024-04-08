using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data
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

        public Task<int> DeletarCursoAsync(CursoEntity curso)
        {
            _context.Curso.Remove(curso);
            return _context.SaveChangesAsync();
        }

        public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) =>
        await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

        public async Task<List<CursoEntity>> ObtemCursosAsync()
        {
            return await _context.Curso.ToListAsync();
        }

        public async Task<CursoEntity> CriaNovoCursoAsync(CursoEntity curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
    }
}
