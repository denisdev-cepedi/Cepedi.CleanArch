namespace Cepedi.Shareable.Requests;
public record AtualizaCursoRequest(int idCurso, string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
