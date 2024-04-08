namespace Cepedi.Domain.Entities;

public class CursoEntity
{
    // Construtor padrão necessário para o Entity Framework
    private CursoEntity() {}

    // Construtor para inicialização direta das propriedades
    public CursoEntity(int id, string nome, string descricao, DateTime inicio, DateTime fim, ProfessorEntity professor)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        DataInicio = inicio;
        DataFim = fim;
        Professor = professor;
    }

    public int Id { get; private set; }

    public string Nome { get; private set; } = default!;

    public string Descricao { get; private set; } = default!;

    public DateTime DataInicio { get; private set; }
    
    public DateTime DataFim { get; private set; }

    // Propriedade de navegação para o Professor
    public ProfessorEntity Professor { get; private set; }

    public int ProfessorId { get; set; } 
}
