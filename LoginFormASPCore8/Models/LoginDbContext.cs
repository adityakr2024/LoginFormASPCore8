using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginFormASPCore8.Models;

public partial class LoginDbContext : DbContext
{
    public LoginDbContext()
    {
    }

    public LoginDbContext(DbContextOptions<LoginDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        { 

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC27C803E36A");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("GENDER");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
