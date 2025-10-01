using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI.Models;

public partial class MvcdbContext : DbContext
{
    public MvcdbContext()
    {
    }

    public MvcdbContext(DbContextOptions<MvcdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("employees");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Empmobile)
                .HasMaxLength(10)
                .HasColumnName("empmobile");
            entity.Property(e => e.Empname)
                .HasMaxLength(50)
                .HasColumnName("empname");
            entity.Property(e => e.Empposition)
                .HasMaxLength(50)
                .HasColumnName("empposition");
            entity.Property(e => e.Empsalary).HasColumnName("empsalary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
