namespace Cepedi.Shareable.Requests;

public record AtualizaCursoRequest(int IdCurso, string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
