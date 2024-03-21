using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using NSubstitute;
using Moq;

namespace Cepedi.Domain.Tests;

public class EditaCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly IProfessorRepository _professorRepository = Substitute.For<IProfessorRepository>();
    private readonly EditaCursoHandler _sut;
    public EditaCursoHandlerTests()
    {
        _sut = new EditaCursoHandler(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task EditaCursoAsync_QuandoEditado_DeveRetornarSucesso()
    {
        // Arrange
        int cursoId = 1;
        var curso = new EditaCursoRequest(
            "Teste",
            "Teste",
            DateTime.Now,
            DateTime.Now,
            1
        );

        // Act
        _cursoRepository.EditaCursoAsync(cursoId, curso).ReturnsForAnyArgs(new CursoEntity(1, "Nome", "descricao", DateTime.Now, DateTime.Now, new ProfessorEntity()));
        _professorRepository.ObtemProfessorPorIdAsync(1).ReturnsForAnyArgs(new ProfessorEntity(1, "Nome", "Especialidade"));

        var result = await _sut.EditaCursoAsync(cursoId, curso);

        // Assert
        Assert.Equal(result, new EditaCursoResponse("Nome", $"O curso tem duração de {DateTime.Now} até {DateTime.Now}", "Nome"));
    }
}
