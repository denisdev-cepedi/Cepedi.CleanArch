namespace Cepedi.Compartilhado.Requests;
public record AlteraCursoRequest(int idCurso, string Nome, string Descricao, DateTime DataInicio, DateTime DataFim, int ProfessorId);
