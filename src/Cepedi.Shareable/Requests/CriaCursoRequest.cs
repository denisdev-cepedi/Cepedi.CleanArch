namespace Cepedi.Shareable.Requests;

public record CriaCursoRequest(string nome, string descricao, DateTime inicio, DateTime fim, int professorId);
