using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;

    public class CriarCursoRequestHandler: IRequestHandler<CriarCursoRequest, CriarCursoResponse>
    {
         private readonly ICursoRepository _cursoRepository;

        public CriarCursoRequestHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public Task<CriarCursoResponse> Handle(CriarCursoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var novoCurso = new CursoEntity()
                {
                    Nome = request.Nome,
                    Descricao = request.Descricao,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim,
                    ProfessorId = request.ProfessorId
                };
                await _cursoRepository.CriaNovoCursoAsync(novoCurso);

                return new CriarCursoResponse(novoCurso.idCurso, novoCurso.Nome);
            catch
            {
                throw;
            }
        }
    }
}