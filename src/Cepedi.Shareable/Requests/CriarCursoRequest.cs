namespace Cepedi.Shareable;

public record CriarCursoRequest(string nome, string descricao, DateTime inicio, DateTime fim, int idProfessor);