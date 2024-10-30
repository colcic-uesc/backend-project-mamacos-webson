﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UescColcicAPI.Services.BD;

#nullable disable

namespace UescColcicAPI.Services.Migrations
{
    [DbContext(typeof(UescColcicDBContext))]
    partial class UescColcicDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("UescColcicAPI.Core.Project", b =>
                {
                    b.Property<int>("IdProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ProjectEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ProjectStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectType")
                        .HasColumnType("TEXT");

                    b.HasKey("IdProject");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("UescColcicAPI.Core.RequestLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientIp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasJwt")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ProcessingTime")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("RequestDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequestLogs", (string)null);
                });

            modelBuilder.Entity("UescColcicAPI.Core.Skill", b =>
                {
                    b.Property<int>("IdSkill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdProject")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdStudent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("IdSkill");

                    b.HasIndex("IdProject");

                    b.HasIndex("IdStudent");

                    b.ToTable("Skill", (string)null);
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student", b =>
                {
                    b.Property<int>("IdStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Course")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Registration")
                        .HasColumnType("TEXT");

                    b.HasKey("IdStudent");

                    b.HasIndex("Registration")
                        .IsUnique();

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("UescColcicAPI.Core.Skill", b =>
                {
                    b.HasOne("UescColcicAPI.Core.Project", null)
                        .WithMany("Skills")
                        .HasForeignKey("IdProject");

                    b.HasOne("UescColcicAPI.Core.Student", null)
                        .WithMany("Skills")
                        .HasForeignKey("IdStudent");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Project", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("UescColcicAPI.Core.Student", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
