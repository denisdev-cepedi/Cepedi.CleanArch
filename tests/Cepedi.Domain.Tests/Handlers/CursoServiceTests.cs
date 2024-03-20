using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using NSubstitute;

namespace Cepedi.Domain.Tests.Handlers;
public class CursoServiceTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly IProfessorRepository _professorRepository = Substitute.For<IProfessorRepository>();
    private readonly ICursoService _iCursoService;

    public CursoServiceTests()
    {
        _iCursoService = new CursoService(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task Create_QuandoCriarCurso_DeveRetornarCursoCriado()
    {
        // Arrange        
        var curso = new CursoEntity()
        {
            Nome = "Curso 1",
            Descricao = "Descrição do curso",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now.AddDays(10),
            ProfessorId = 1
        };

        var cursoRequest = new CriaCursoRequest(curso.Nome, curso.Descricao, curso.DataInicio, curso.DataFim, curso.ProfessorId);
        _professorRepository.GetById(curso.ProfessorId, default).ReturnsForAnyArgs(new ProfessorEntity(cursoRequest.ProfessorId, "Nome", "Especialidade"));
        _cursoRepository.Create(curso, default).ReturnsForAnyArgs(curso);

        // Act
        var result = await _iCursoService.Create(cursoRequest, default);

        // Assert
        Assert.Equal(cursoRequest.Nome, result.Nome);
    }

}
