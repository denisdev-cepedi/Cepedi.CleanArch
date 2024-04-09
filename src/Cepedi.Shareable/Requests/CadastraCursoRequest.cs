namespace Cepedi.Shareable.Requests;
public record CadastraCursoRequest(string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
