using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Pessoa.Dados.EntityTypeConfiguration;
public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<PessoaEntity>
{
    public void Configure(EntityTypeBuilder<PessoaEntity> builder)
    {
        builder.ToTable("Pessoa");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Cpf).IsRequired().HasMaxLength(11);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(250);
        builder.Property(p => p.Telefone).IsRequired().HasMaxLength(14);
        builder.Property(p => p.DataNascimento).IsRequired();
        builder.Property(p => p.Genero).IsRequired();
        builder.Property(p => p.EstadoCivil).IsRequired();
        builder.Property(p => p.Nacionalidade).IsRequired();

        builder.HasMany(p => p.Enderecos).WithOne(e => e.Pessoa).HasForeignKey(p => p.IdPessoa);
    }
}
