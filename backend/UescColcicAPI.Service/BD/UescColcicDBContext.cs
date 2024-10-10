using System;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class UescColcicDBContext : DbContext
{
   public DbSet<Project> Project { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
        //modelBuilder.Entity<Project>().ToTable("Project"); // Tranforma a classe Project em uma tabela no banco de dados
        //modelBuilder.Entity<Project>().HasKey(p => p.ProjectId); // Define que a chave primaria da tabela Project é ProjectId
        // modelBuilder.Entity<Project>().HasMany(p => p.Skills).WithOne(p => p.ProjectId);
        
        modelBuilder.Entity<Project>().ToTable("Project");
        modelBuilder.Entity<Project>().HasKey(p => p.IdProject);
        
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("Data Source = C:/Users/Kauan Teles/backend-project-mamacos-webson/backend/UescColcicAPI.Service/UescColcicAPI.db");
   }
}