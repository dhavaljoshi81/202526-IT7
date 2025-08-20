using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IT7A_StudentAPI_EFAppCS.SchoolModels;

public partial class It42025demoDbContext : DbContext
{
    private IConfiguration _configuration;
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
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StudentDBConStr"));

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
