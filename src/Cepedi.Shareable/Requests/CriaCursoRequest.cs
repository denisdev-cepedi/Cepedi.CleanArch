namespace Cepedi.Shareable.Requests;
public record CriarCursoRequest(string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
