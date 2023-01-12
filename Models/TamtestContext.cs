using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ECRUD.Models;

public partial class TamtestContext : DbContext
{


    public TamtestContext(DbContextOptions<TamtestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Idperson);

            entity.ToTable("Person");

            entity.Property(e => e.Idperson)
                .HasMaxLength(50)
                .HasColumnName("idperson");
            entity.Property(e => e.Borthdate)
                .HasColumnType("date")
                .HasColumnName("borthdate");
            entity.Property(e => e.Brothers).HasColumnName("brothers");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserPhoto)
                .HasColumnType("image")
                .HasColumnName("user_photo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
