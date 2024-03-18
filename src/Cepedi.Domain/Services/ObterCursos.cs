namespace Cepedi.Domain.Services;

using Cepedi.Domain.Repository;
public class ObterCursos : IObterCursos{

    private readonly ApplicationDbContext _context;

    ObterCursos(ApplicationDbContext context){
        _context = context;
    }
    public Task<CursoEntity> ObterCursos(){

        var result = _context.Curso.ToString();
        return Task.FromResult(result);
    }


}