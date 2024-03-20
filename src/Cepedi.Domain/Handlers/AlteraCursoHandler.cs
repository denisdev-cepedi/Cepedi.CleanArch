using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Handlers
{
    public class AlteraCursoHandler: IAlteraCursoHandler
    {
        private readonly ICursoRepository _cursoRepository;
        public AlteraCursoHandler(ICursoRepository cursoRepository) => _cursoRepository = cursoRepository;
        public async Task<int> AlterarCursoAsync(AlteraCursoRequest request)
        {
            var curso = await _cursoRepository.ObtemCursoPorIdAsync(request.idCurso);
            if (curso == null){
                throw new Exception("Curso não encontrado");
            }
            curso.Nome = request.Nome;
            curso.Descricao = request.Descricao;
            curso.DataFim = request.DataFim;
            curso.DataInicio = request.DataInicio;
            curso.ProfessorId = request.ProfessorId;
            return await _cursoRepository.AlterarCursoAsync(curso);

        }
    }
}