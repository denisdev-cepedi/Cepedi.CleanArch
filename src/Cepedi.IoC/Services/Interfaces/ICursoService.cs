using Cepedi.Domain.Entities;

namespace Cepedi.IoC.Services.Interfaces;
public interface ICursoService
{
    CursoEntity GetById(int idCurso);
}
