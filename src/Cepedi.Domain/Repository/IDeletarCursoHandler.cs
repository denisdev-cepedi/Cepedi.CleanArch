namespace Cepedi.Domain.Repository;

public interface IDeletarCursoHandler
{
    public Task<int> DeletarCursoAsync(int idCurso);
}
