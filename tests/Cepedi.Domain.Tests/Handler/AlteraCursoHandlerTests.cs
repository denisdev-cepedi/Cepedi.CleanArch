using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Shareable.Requests;
using NSubstitute;

namespace Cepedi.Domain.Tests.Handler
{
    public class AlteraCursoHandlerTests
    {
        private readonly ICursoRepository _repository = Substitute.For<ICursoRepository>();
        private readonly AlteraCursoHandler _alteraCurso;
        public AlteraCursoHandlerTests() => _alteraCurso = new AlteraCursoHandler(_repository);

        [Fact]
        public async Task AlteraCursoHandlerAsync_QuandoAlteraCurso_DeveRetornarSucesso()
        {
            // Arrange
            var curso = new AlteraCursoRequest(
                2, "Nome do curso", "descricao do curso", DateTime.Now, DateTime.Now, 1);

            var cursoExistente = new CursoEntity
            {
                Id = curso.idCurso,
                Nome = "Nome do Curso Existente",
                Descricao = "Descrição do Curso Existente",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now,
                ProfessorId = 1
            };

            _repository.ObtemCursoPorIdAsync(curso.idCurso).Returns(cursoExistente);
            _repository.AlterarCursoAsync(Arg.Any<CursoEntity>()).Returns(1);

            // Act
            var result = await _alteraCurso.AlterarCursoAsync(curso);

            // Assert
            Assert.Equal(1, result);
            Assert.Equal("Nome do curso", cursoExistente.Nome);
            Assert.Equal("descricao do curso", cursoExistente.Descricao);

        }
    }
}