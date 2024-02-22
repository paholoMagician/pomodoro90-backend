﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pomoBack.Models;

public partial class pomodoro90Context : DbContext
{
    public pomodoro90Context(DbContextOptions<pomodoro90Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PomodoroTasks> PomodoroTasks { get; set; }

    public virtual DbSet<TaskGroup> TaskGroup { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PomodoroTasks>(entity =>
        {
            entity.ToTable("pomodoroTasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ciclos).HasColumnName("ciclos");
            entity.Property(e => e.Descripciontarea)
                .HasMaxLength(550)
                .IsUnicode(false)
                .HasColumnName("descripciontarea");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechacrea)
                .HasColumnType("datetime")
                .HasColumnName("fechacrea");
            entity.Property(e => e.Idusercrea).HasColumnName("idusercrea");
            entity.Property(e => e.Lognbreakmin).HasColumnName("lognbreakmin");
            entity.Property(e => e.Lognbreakminterminal).HasColumnName("lognbreakminterminal");
            entity.Property(e => e.Nombretarea)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombretarea");
            entity.Property(e => e.Pomomin).HasColumnName("pomomin");
            entity.Property(e => e.Pomominterminal).HasColumnName("pomominterminal");
            entity.Property(e => e.Sbreakmin).HasColumnName("sbreakmin");
            entity.Property(e => e.Sbreakminterminal).HasColumnName("sbreakminterminal");
        });

        modelBuilder.Entity<TaskGroup>(entity =>
        {
            entity.HasKey(e => e.Idgrupo);

            entity.ToTable("taskGroup");

            entity.Property(e => e.Idgrupo).HasColumnName("idgrupo");
            entity.Property(e => e.DescripGrupo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripGrupo");
            entity.Property(e => e.Idpromodoro).HasColumnName("idpromodoro");
            entity.Property(e => e.Idusercrea).HasColumnName("idusercrea");
            entity.Property(e => e.Img)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.NombreGrupo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreGrupo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iduser);

            entity.ToTable("usuario");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EstadoConexion).HasColumnName("estadoConexion");
            entity.Property(e => e.Fecrea)
                .HasColumnType("datetime")
                .HasColumnName("fecrea");
            entity.Property(e => e.Img)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Pais)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pais");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}