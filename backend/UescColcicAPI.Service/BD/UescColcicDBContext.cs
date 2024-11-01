using System;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class UescColcicDBContext : DbContext
{
   public DbSet<Project> Project { get; set; }
   public DbSet<Skill> Skill { get; set; }
   public DbSet<Student> Student { get; set; }
   public DbSet<User> User { get; set; }
   public DbSet<RequestLog> RequestLogs { get; set; } 

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().ToTable("Project").HasKey(p => p.IdProject);
        modelBuilder.Entity<Project>().Property(p => p.IdProject).ValueGeneratedOnAdd();        

        modelBuilder.Entity<Student>().ToTable("Student").HasKey(s => s.IdStudent);
        modelBuilder.Entity<Student>().HasMany(s => s.Skills).WithOne().HasForeignKey(s => s.IdStudent);
        modelBuilder.Entity<Student>().HasIndex(s => s.Registration).IsUnique();
        

        modelBuilder.Entity<Skill>().ToTable("Skill").HasKey(p => p.IdSkill);
       
        // Define que uma Skill pode ter um IdProject opcional (nullable)
        modelBuilder.Entity<Skill>()
            .HasOne<Project>()
            .WithMany(p => p.Skills)
            .HasForeignKey(s => s.IdProject)
            .IsRequired(false); // Chave estrangeira opcional

        // Define que uma Skill pode ter um IdStudent opcional (nullable)
        modelBuilder.Entity<Skill>()
            .HasOne<Student>()
            .WithMany(s => s.Skills)
            .HasForeignKey(s => s.IdStudent)
            .IsRequired(false); // Chave estrangeira opcional


        modelBuilder.Entity<RequestLog>().ToTable("RequestLogs").HasKey(p => p.Id);

        modelBuilder.Entity<User>().ToTable("User").HasKey(p => p.IdUser);
        modelBuilder.Entity<User>()
        .HasOne(e => e.Student)
        .WithOne(e => e.User)
        .HasForeignKey<Student>(e => e.IdUser)
        .IsRequired();
    }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("Data Source =  C:/Users/gugud/Web_2024_2/backend/UescColcicAPI.Service/UescColcicAPI.db");
   }
}                      