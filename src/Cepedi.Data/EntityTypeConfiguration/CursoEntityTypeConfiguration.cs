using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.Data.EntityTypeConfiguration;
public class CursoEntityTypeConfiguration : IEntityTypeConfiguration<CursoEntity>
{
    public void Configure(EntityTypeBuilder<CursoEntity> builder)
    {
        builder.ToTable("Curso");
        builder.HasKey(c => c.Id); // Define a chave primária

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Descricao).HasMaxLength(255);
        builder.Property(c => c.DataInicio).IsRequired();
        builder.Property(c => c.DataFim).IsRequired();

        // Define o relacionamento com Professor (um para muitos)
        builder.HasOne(c => c.Professor)
               .WithMany(p => p.Cursos)
               .HasForeignKey(c => c.ProfessorId)
               .IsRequired();
    }
}
