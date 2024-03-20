namespace Cepedi.Shareable.Requests;

public record CriaCursoRequest(string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
