namespace Cepedi.Shareable.Requests;

public record EditaCursoRequest(string nome, string descricao, DateTime inicio, DateTime fim, int professorId);