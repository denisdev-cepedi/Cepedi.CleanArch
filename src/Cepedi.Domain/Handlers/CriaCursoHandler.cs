using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers
{
    public class CriaCursoHandler : IRequestHandler<CriaCursoRequest, CriaCursoResponse>
    {
        private readonly ICursoRepository _cursoRepository;

        public CriaCursoHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<int> CriarCursoAsync(CriaCursoRequest request)
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

        public async Task<CriaCursoResponse> Handle(CriaCursoRequest request, CancellationToken cancellationToken)
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
                await _cursoRepository.CriaNovoCursoAsync(novoCurso);
                return new CriaCursoResponse(novoCurso.Nome, novoCurso.Descricao, novoCurso.ProfessorId);
            } catch
            {
                throw;
            }
        }
    }
}
