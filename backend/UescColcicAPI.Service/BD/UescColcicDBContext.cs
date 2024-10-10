using System;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class UescColcicDBContext : DbContext
{
   public DbSet<Student> Students { get; set; }
   public DbSet<Skill> Skill { get; set; }
   public DbSet<Project> Project { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
        //modelBuilder.Entity<Project>().ToTable("Project"); // Tranforma a classe Project em uma tabela no banco de dados
        //modelBuilder.Entity<Project>().HasKey(p => p.ProjectId); // Define que a chave primaria da tabela Project é ProjectId
        // modelBuilder.Entity<Project>().HasMany(p => p.Skills).WithOne(p => p.ProjectId);
        
        modelBuilder.Entity<Student>().HasKey(p => p.IdStudent);
        
        modelBuilder.Entity<Skill>().HasKey(p => p.IdSkill);
        
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("Data Source = ./UescColcicAPI.db");
   }
}