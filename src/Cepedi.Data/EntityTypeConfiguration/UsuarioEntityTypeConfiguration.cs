using Cepedi.BancoCentral.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.BancoCentral.Data.EntityTypeConfiguration;
public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(c => c.Id); // Define a chave primária

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(150);
        builder.Property(c => c.Email).HasMaxLength(255);
        builder.Property(c => c.Cpf).IsRequired().HasMaxLength(12);
        builder.Property(c => c.Celular).IsRequired().HasMaxLength(12);
        builder.Property(c => c.DataNascimento).IsRequired();
    }
}
