namespace Cepedi.IoC.services;
using Cepedi.Data;
using Cepedi.Domain.Entities;


public class CursoServiceCollection
{
    private readonly ApplicationDbContext _context;
    public CursoServiceCollection(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public CursoEntity GetByID(int ID){
      return _context.Curso.Find(ID) ?? throw new Exception();
    }
}
