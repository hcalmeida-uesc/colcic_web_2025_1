using System;
using ddd_project.Domain;
using Microsoft.EntityFrameworkCore;

namespace ddd_project.Infrastructure.ORM;

public class ColcicExtensaoContext : DbContext
{
   public DbSet<Aluno> Alunos { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
	  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Aluno>().ToTable("Alunos").HasKey(a => a.Id);
	  
    }

}
