using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers
{
    public class CriaCursoHandler: IRequestHandler<CriaCursoRequest, CriaCursoResponse>
    {
         private readonly ICursoRepository _cursoRepository;

        public CriaCursoHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public Task<CriaCursoResponse> Handle(CriaCursoRequest request, CancellationToken cancellationToken)
        {
            try
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
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}