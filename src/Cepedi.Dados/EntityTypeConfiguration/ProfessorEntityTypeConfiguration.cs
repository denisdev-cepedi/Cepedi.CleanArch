using System.Diagnostics.CodeAnalysis;
using Cepedi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Dados.EntityTypeConfiguration;

[ExcludeFromCodeCoverage]
public class ProfessorEntityTypeConfiguration : IEntityTypeConfiguration<ProfessorEntity>
{
    public void Configure(EntityTypeBuilder<ProfessorEntity> builder)
    {
        builder.ToTable("Professor");
        builder.HasKey(e => e.Id);

        builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);

        builder.Property(p => p.Especialidade).IsRequired().HasMaxLength(100);
    }
}
