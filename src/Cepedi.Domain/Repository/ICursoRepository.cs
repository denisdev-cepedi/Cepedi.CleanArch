using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain;

public interface ICursoRepository
{
    Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso);
    Task<List<CursoEntity>> ObtemCursosAsync();
    Task<CursoEntity> CriaNovoCursoAsync(CursoEntity curso);
    Task<int> AlterarCursoAsync(CursoEntity curso);

    Task<int> DeletarCursoAsync(CursoEntity curso);
}

public interface IWhatsApp
{
    Task<string> EnviarMensagemWhatsAppAsync(string numeroTelefone, string mensagem);
}
