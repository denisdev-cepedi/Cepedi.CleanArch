public class AtualizarCursoRequest
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    
    // Propriedades do professor
    public int ProfessorId { get; set; }
    public string ProfessorNome { get; set; }
    public string ProfessorEspecialidade { get; set; }
}
