using Cepedi.BancoCentral.Domain.Entities;

namespace Cepedi.BancoCentral.Domain;

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
