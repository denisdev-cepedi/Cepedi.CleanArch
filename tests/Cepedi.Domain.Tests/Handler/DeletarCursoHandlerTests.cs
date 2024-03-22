using Cepedi.Domain.Entities;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class DeletarCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();

    private readonly DeletarCursoHandler _sut;

    public DeletarCursoHandlerTests (){
        _sut = new DeletarCursoHandler(_cursoRepository);
    }

    [Fact]
    public async Task DeletarCurso_PassandoIDExistente_DeveRetornar1 (){
        // Arrange
        int id = 1;
        var curso = new CursoEntity
        {
            Id = 1,
            Nome = "nomeDel",
            Descricao = "descricao",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            ProfessorId = 1,
        };
        _cursoRepository.ObtemCursoPorIdAsync(id).ReturnsForAnyArgs(curso);
        _cursoRepository.DeletarCursoAsync(curso).ReturnsForAnyArgs(1);

        //act
        var result = await _sut.DeletarCursoAsync(id);
        
        //assets
        Assert.Equal(1 ,result );
    }
}
