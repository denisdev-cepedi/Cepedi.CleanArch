﻿using System.Diagnostics.CodeAnalysis;
using Cepedi.BancoCentral.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<ProfessorEntity> Professor { get; set; } = default!;
    public DbSet<CursoEntity> Curso { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
