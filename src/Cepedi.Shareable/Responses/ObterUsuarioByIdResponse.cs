namespace Cepedi.Shareable.Responses;
public record ObterUsuarioByIdResponse( int Id, string Nome, DateTime DataNascimento, string Cpf, string Celular, bool CelularValidado, string Email);
