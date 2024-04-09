namespace Cepedi.Shareable.Responses;
public record ObterUsuariosResponse( int Id, string Nome, DateTime DataNascimento, string Cpf, string Celular, bool CelularValidado, string Email);