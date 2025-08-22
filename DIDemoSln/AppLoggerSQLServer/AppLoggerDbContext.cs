using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppLoggerSQLServer;

public partial class AppLoggerDbContext : DbContext
{
    public AppLoggerDbContext()
    {
    }

    public AppLoggerDbContext(DbContextOptions<AppLoggerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppDataLog> AppDataLogs { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=desktop-g78qdqr;Initial Catalog=AppLoggerDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppDataLog>(entity =>
        {
            entity.ToTable("AppDataLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.ClassName).HasMaxLength(50);
            entity.Property(e => e.Message).HasMaxLength(200);
            entity.Property(e => e.MethodName).HasMaxLength(50);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorId);

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorId).HasColumnName("ErrorID");
            entity.Property(e => e.ErrorMessage).HasMaxLength(100);
            entity.Property(e => e.ErrorTime).HasColumnType("datetime");
            entity.Property(e => e.ExceptionType).HasMaxLength(200);
            entity.Property(e => e.StackTrace).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
