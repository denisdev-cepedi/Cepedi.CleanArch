namespace Cepedi.Shareable.Responses;
public record CriarUsuarioResponse(int idUsuario, string nome);
public record AlterarUsuarioResponse(string nome);
public record ApagarUsuarioResponse();
public record ApagarCursoResponse(string retorno);
public record ObterUsuarioResponse(IEnumerable<ObterUsuarioResponse> usuarios);
