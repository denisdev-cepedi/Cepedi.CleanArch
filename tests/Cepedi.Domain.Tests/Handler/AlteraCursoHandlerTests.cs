using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Shareable.Requests;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class AlteraCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly AlteraCursoHandler _sut;

    public AlteraCursoHandlerTests() => _sut = new AlteraCursoHandler(_cursoRepository);

    [Fact]

    public async Task AlterarCursoAsync_PassandoIdValido_Retorna1()
    {
        //Arrange

        var cursoNovo = new AlteraCursoRequest(1, "stringNome", "string Descricao", DateTime.Now, DateTime.Now, 1);
        var curso = new CursoEntity
        {
            Id = 1,
            Nome = "nome",
            Descricao = "descricao",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            ProfessorId = 1,

        };
        _cursoRepository.ObtemCursoPorIdAsync(cursoNovo.idCurso).ReturnsForAnyArgs(curso);
        _cursoRepository.AlterarCursoAsync(curso).ReturnsForAnyArgs(1);

        //Act
        var result = await _sut.AlterarCursoAsync(cursoNovo);

        //Assert
        Assert.Equal(1,result);

    }

}
