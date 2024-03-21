namespace Cepedi.Shareable;


public record AlterarCursoRequest(int idCurso, string nome, string descricao, DateTime inicio, DateTime fim, int idProfessor);