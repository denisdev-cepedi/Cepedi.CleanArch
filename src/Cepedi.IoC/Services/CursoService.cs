using Cepedi.Data;
using Cepedi.Domain.Entities;
using Cepedi.IoC.Services.Interfaces;
using Cepedi.Shareable.Exceptions;

namespace Cepedi.IoC.Services;
public class CursoService : ICursoService
{
    private readonly ApplicationDbContext _context;
    public CursoService(ApplicationDbContext context){
        _context = context;
    }

    public CursoEntity GetById(int idCurso){
        return _context.Curso.Find(idCurso) ?? throw new CursoNotFoundException();
    }
}
