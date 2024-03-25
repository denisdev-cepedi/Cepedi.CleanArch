namespace Cepedi.Shareable.Exceptions
{
    public class ProfessorNaoEncontradoException : Exception
    {
        public ProfessorNaoEncontradoException(int id) : base($"Professor com o id {id} nao encontrado.") { }
    }
}
