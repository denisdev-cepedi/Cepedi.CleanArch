namespace Cepedi.Shareable.Requests;

public record CadastraCursoRequest(string nome, string descricao, DateTime inicio, DateTime fim, int professorId);
