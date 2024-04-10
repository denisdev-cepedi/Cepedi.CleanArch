using Cepedi.Banco.Pessoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Banco.Pessoa.Data.EntityTypeConfiguration;
public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("Pessoa");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(250);
        builder.Property(p => p.Cpf).IsRequired().HasMaxLength(11);
        builder.Property(p => p.Telefone).IsRequired().HasMaxLength(14);
        builder.Property(p => p.DataNascimento).IsRequired();
        builder.Property(p => p.Genero).IsRequired();
        builder.Property(p => p.EstadoCivil).IsRequired();
        builder.Property(p => p.Nacionalidade).IsRequired();

        builder.HasOne(p => p.Endereco).WithOne(e => e.Pessoa).HasForeignKey<PessoaEntity>(p => p.Endereco);
    }
}
