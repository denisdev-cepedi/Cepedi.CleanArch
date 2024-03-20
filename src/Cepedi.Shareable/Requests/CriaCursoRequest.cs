namespace Cepedi.Shareable.Requests;

public record class CriaCursoRequest(string nome, string descricao, DateTime inicio, DateTime fim, int professorId);
