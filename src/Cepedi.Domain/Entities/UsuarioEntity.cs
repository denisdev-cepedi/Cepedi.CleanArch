﻿namespace Cepedi.BancoCentral.Domain.Entities;
public class UsuarioEntity
{
    public int Id { get; set; }

    public string Nome { get; set; } = default!;

    public DateTime DataNascimento { get; set; }

    public string Cpf { get; set; } = default!;

    public string Celular { get; set; } = default!;

    public bool CelularValidado { get; set; }

    public string Email { get; set; } = default!;

    internal void Atualizar(int id, DateTime dataNascimento, string celular, bool celularValidado, string email, string cpf)
    {
    
        DataNascimento = dataNascimento;
        Celular = celular;
        CelularValidado = celularValidado;
        Email = email;
        Cpf = cpf;
        
    }
}
