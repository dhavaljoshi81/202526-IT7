using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace IT7B_EFCoreDemoAppCS.Models;

public partial class It42025demoDbContext : DbContext
{
    private IConfiguration? _configuration { get; set; }
    public It42025demoDbContext()
    {        
    }

    public It42025demoDbContext(DbContextOptions<It42025demoDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("IT7BDBConnectionString")
            );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("StudentID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
