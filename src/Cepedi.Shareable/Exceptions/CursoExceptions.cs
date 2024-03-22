namespace Cepedi.Shareable.Exceptions
{
    public class CursoNaoEncontradoException : Exception
    {
        public CursoNaoEncontradoException(int id) : base($"Curso com o id {id} não encontrado.") { }
    }
}
