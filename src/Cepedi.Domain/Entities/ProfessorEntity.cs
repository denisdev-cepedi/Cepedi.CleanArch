namespace Cepedi.Domain.Entities;
public class ProfessorEntity
{
    public ProfessorEntity(int id, string nome, string especialidade)
    {
        Id = id;
        Nome = nome;
        Especialidade = especialidade;
    }

    public int Id { get; set; }

    public string Nome { get; set; } = default!;
    
    public string Especialidade { get; set; } = default!;

    public List<CursoEntity> Cursos { get; set; } = new();
}
