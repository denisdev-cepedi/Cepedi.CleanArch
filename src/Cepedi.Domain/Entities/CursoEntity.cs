namespace Cepedi.Domain.Entities;

public class CursoEntity
{
    public CursoEntity()
    {        
    }

    public CursoEntity(int id, string nome, string descricao, DateTime inicio, DateTime fim, ProfessorEntity professor)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        DataInicio = inicio;
        DataFim = fim;
        Professor = professor;
    }

    public int Id { get; set; }

    public string Nome { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public DateTime DataInicio { get; set; }
    
    public DateTime DataFim { get; set; }

    public ProfessorEntity Professor { get; set; }

    public int ProfessorId { get; set; } 

}
