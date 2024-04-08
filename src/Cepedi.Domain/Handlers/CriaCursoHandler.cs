using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Handlers
{
    public class CriaCursoHandler: ICriarCursoHandler
    {
         private readonly ICursoRepository _cursoRepository;

        public CriaCursoHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<int> CriarCursoAsync(CriarCursoRequest request)
        {
            var novoCurso = new CursoEntity
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ProfessorId = request.ProfessorId
            };

            return await _cursoRepository.CriaNovoCursoAsync(novoCurso);
        }

    }
}