using Cepedi.Domain.Entities;
using Cepedi.Shareable.Responses;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class ObtemCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly IProfessorRepository _professorRepository = Substitute.For<IProfessorRepository>();

    private readonly ObtemCursoHandler _sut;

    public ObtemCursoHandlerTests()
    {
        _sut = new ObtemCursoHandler(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task ObterCursoAsync_PassandoID_DeveRetornar1()
    {
        // Arrange
        int id = 1;
        var curso = new CursoEntity
        {
            Id = 1,
            Nome = "nome",
            Descricao = "descricao",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            ProfessorId = 1,
        };

        var professor = new ProfessorEntity(curso.ProfessorId, "nome", "especialidade");
        var duracao = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";


        _cursoRepository.ObtemCursoPorIdAsync(id).ReturnsForAnyArgs(curso);
        _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId).ReturnsForAnyArgs(professor);

        //Act
        var result = await _sut.ObterCursoAsync(id);

        //Assets
        Assert.Equal(new ObtemCursoResponse(curso.Nome, duracao, professor.Nome), result);

    }

    [Fact]
    public async Task ObterCursoAsync_ListadeTodosOsCursos_DeveRetornar1()
    {
        // Arrange
        var cursos = new List<CursoEntity>
    {
        new CursoEntity
        {
            Id = 1,
            Nome = "Curso 1",
            Descricao = "Descrição do Curso 1",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now.AddDays(30),
            ProfessorId = 1
        },
        new CursoEntity
        {
            Id = 2,
            Nome = "Curso 2",
            Descricao = "Descrição do Curso 2",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now.AddDays(60),
            ProfessorId = 2
        }
    };

        var professores = new List<ProfessorEntity>
    {
        new ProfessorEntity(1, "Professor 1", "Especialidade 1"),
        new ProfessorEntity(2, "Professor 2", "Especialidade 2")
    };

        _cursoRepository.ObtemCursosAsync().ReturnsForAnyArgs(cursos);
        _professorRepository.ObtemProfessorPorIdAsync(Arg.Any<int>()).ReturnsForAnyArgs(professores.First(), professores.Last());

        var expectedResponses = new List<ObtemCursoResponse>
    {
        new ObtemCursoResponse(cursos[0].Nome, $"O curso tem duração de {cursos[0].DataInicio} até {cursos[0].DataFim}", professores[0].Nome),
        new ObtemCursoResponse(cursos[1].Nome, $"O curso tem duração de {cursos[1].DataInicio} até {cursos[1].DataFim}", professores[1].Nome)
    };

        // Act
        var result = await _sut.ObterCursosAsync();

        // Assert
        Assert.Equal(expectedResponses, result);

    }

}
