using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Repository;

namespace Cepedi.Domain.Handlers
{
    public class ExcluirCursoHandler : IExcluirCursoHandler
    {
        
        private readonly ICursoRepository _cursoRepository;
        public ExcluirCursoHandler(ICursoRepository cursoRepository) => _cursoRepository = cursoRepository;
        public Task<int> ExcluirCursoAsync(int idCurso)
        {
            return _cursoRepository.ExcluirCursoAsync(idCurso);
        }
    }
}