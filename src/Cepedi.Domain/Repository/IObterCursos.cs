namespace Cepedi.Domain.Repository;

public interface IObterCurso
{
   Task<ObtemCursosResponse> ObterCursos();
}