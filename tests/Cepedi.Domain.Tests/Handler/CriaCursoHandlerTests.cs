using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Handlers;
using Cepedi.Shareable.Requests;
using NSubstitute;

namespace Cepedi.Domain.Tests.Handler
{
    public class CriaCursoHandlerTests
    {
        private readonly ICursoRepository _repository = Substitute.For<ICursoRepository>();
        private readonly CriaCursoHandler _criaCurso;

        public CriaCursoHandlerTests() => _criaCurso = new CriaCursoHandler(_repository);

        [Fact]
        public async Task CriaCursoHandlerAsync_QuandoCriaCurso_DeveRetornarSucesso()
        {
            // Arrange
            var curso = new CriaCursoRequest("Nome do curso", "Descricao do curso", DateTime.Now, DateTime.Now, 1);
            _repository.CriaNovoCursoAsync(new()).ReturnsForAnyArgs(1);

            // Act
            var result = await _criaCurso.CriarCursoAsync(curso);

            // Assert
            Assert.Equal(1, result);
        }
    }
}