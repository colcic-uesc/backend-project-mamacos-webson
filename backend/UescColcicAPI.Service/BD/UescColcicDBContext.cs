using System;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class UescColcicDBContext : DbContext
{
   public DbSet<Project> Project { get; set; }
   public DbSet<Skill> Skill { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Project>()
        .ToTable("Project")
        .HasKey(p => p.IdProject);

    modelBuilder.Entity<Project>()
        .HasMany(p => p.Skills)
        .WithOne()
        .HasForeignKey(p => p.IdProject); // A chave estrangeira correta é IdProject

    modelBuilder.Entity<Skill>()
        .ToTable("Skill")
        .HasKey(p => p.IdSkill);

    modelBuilder.Entity<Skill>()
        .HasOne<Project>() // Define que Skill está relacionada a Project
        .WithMany(p => p.Skills)
        .HasForeignKey(s => s.IdProject); // Chave estrangeira correta em Skill
}

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("Data Source = C:/Users/gugud/Web_2024_2/backend/UescColcicAPI.Service/UescColcicAPI.db");
   }
}