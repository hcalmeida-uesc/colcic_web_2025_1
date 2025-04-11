using System;
using ddd_project.Domain;
using Microsoft.EntityFrameworkCore;

namespace ddd_project.Infrastructure.ORM;

public class ColcicExtensaoContext : DbContext
{
   public DbSet<Aluno> Alunos { get; set; }
   public DbSet<Atividade> Atividades { get; set; }
   public DbSet<AlunoAtividade> AlunoAtividades { get; set; }
    
     

   public ColcicExtensaoContext(DbContextOptions<ColcicExtensaoContext> options) : base(options)
    {
    }

    
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
	  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Aluno>().ToTable("Alunos").HasKey(a => a.Id);
        modelBuilder.Entity<Aluno>().HasMany(a => a.Atividades).WithMany(a => a.Alunos).UsingEntity<AlunoAtividade>(j => j.ToTable("AlunosAtividades"));
        modelBuilder.Entity<Aluno>().HasIndex(a => a.Matricula).IsUnique();

        modelBuilder.Entity<Atividade>().ToTable("Atividades").HasKey(a => a.Id);
        modelBuilder.Entity<Atividade>().HasMany(a => a.Alunos).WithMany(a => a.Atividades).UsingEntity<AlunoAtividade>(j => j.ToTable("AlunosAtividades"));

        modelBuilder.Entity<AlunoAtividade>().ToTable("AlunosAtividades").HasKey(a => new { a.AlunoId, a.AtividadeId });
        
	  
    }

}
