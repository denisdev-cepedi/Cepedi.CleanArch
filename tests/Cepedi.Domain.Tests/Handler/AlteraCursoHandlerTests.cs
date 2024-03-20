using Cepedi.Shareable.Requests;
using Cepedi.Domain.Handlers;
using NSubstitute;
using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Tests;

public class AlteraCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();

    private readonly AlteraCursoHandler _sut;
    public AlteraCursoHandlerTests(){
        _sut = new AlteraCursoHandler(_cursoRepository);
    }

    [Fact]
    public async Task AlterarCursoAsync_QuandoCursoForNulo_DeveRetornarException()
    {
        // Arrange
        var curso = new AlteraCursoRequest
        (1, "Nome", "Descricao", DateTime.Now,
         DateTime.Now,1);

        var cursoMoq = new CursoEntity();

        _cursoRepository.ObtemCursoPorIdAsync(curso.idCurso).Returns(cursoMoq);

        // Act
        var result = await _sut.AlterarCursoAsync(curso);

        // Assert 
        Assert.Equal(result, default(int));
    }
}
