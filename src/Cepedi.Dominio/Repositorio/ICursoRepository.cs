using Cepedi.Dominio.Entidades;

namespace Cepedi.Dominio;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<List<CursoEntity>> ObtemCursosAsync();
    Task<int> CriaNovoCursoAsync(CursoEntity curso);
    Task<int> AlterarCursoAsync(CursoEntity curso);
}

public interface IWhatsApp 
{
    Task<string> EnviarMensagemWhatsAppAsync(string numeroTelefone, string mensagem);
}
