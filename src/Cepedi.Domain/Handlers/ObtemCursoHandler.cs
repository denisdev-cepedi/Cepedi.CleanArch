using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using System.Threading.Tasks;

namespace Cepedi.Domain
{
    public class ObtemCursoHandler : IObtemCursoHandler
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IProfessorRepository _professorRepository;

        public ObtemCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
        {
            _cursoRepository = cursoRepository;
            _professorRepository = professorRepository;
        }

        public async Task<ObtemCursoResponse> ObterCursoAsync(int idCurso)
        {
            var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);
            if (curso == null)
            {
                return null;
            }

            var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);
            if (professor == null)
            {
                return null;
            }

            var duracao = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";
            return new ObtemCursoResponse(curso.Nome, duracao, professor.Nome);
        }
    }
}
