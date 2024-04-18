using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Pessoa.Data.EntityTypeConfiguration;


public class EnderecoEntityTypeConfiguration : IEntityTypeConfiguration<EnderecoEntity>
{
    public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
    {
        builder.ToTable("Endereco");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Cep).IsRequired().HasMaxLength(8);
        builder.Property(e => e.Logradouro).IsRequired().HasMaxLength(250);
        builder.Property(e => e.Complemento).HasMaxLength(250);
        builder.Property(e => e.Bairro).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Cidade).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Uf).IsRequired().HasMaxLength(2);
        builder.Property(e => e.Pais).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Numero).IsRequired().HasMaxLength(10);

    }
}

