namespace Cepedi.Banco.Pessoa.Dominio.Entidades;
public class UsuarioEntity
{
    public int Id { get; set; }

    public string Nome { get; set; } = default!;

    public DateTime DataNascimento { get; set; }

    public string Cpf { get; set; } = default!;

    public string Celular { get; set; } = default!;

    public bool CelularValidado { get; set; }

    public string Email { get; set; } = default!;

    internal void Atualizar(string nome)
    {
        Nome = nome;
    }
}
