using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppLoggerPostgres;

public partial class AppLoggerDbContext : DbContext
{
    public AppLoggerDbContext()
    {
    }

    public AppLoggerDbContext(DbContextOptions<AppLoggerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appdatalog> Appdatalogs { get; set; }

    public virtual DbSet<Errorlog> Errorlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=AppLoggerDB;Username=postgres;Password=postgres@1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appdatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("appdatalog_pkey");

            entity.ToTable("appdatalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Appname)
                .HasMaxLength(50)
                .HasColumnName("appname");
            entity.Property(e => e.Classname)
                .HasMaxLength(50)
                .HasColumnName("classname");
            entity.Property(e => e.Message)
                .HasMaxLength(200)
                .HasColumnName("message");
            entity.Property(e => e.Methodname)
                .HasMaxLength(50)
                .HasColumnName("methodname");
            entity.Property(e => e.Timestamp).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Errorlog>(entity =>
        {
            entity.HasKey(e => e.Errorid).HasName("errorlog_pkey");

            entity.ToTable("errorlog");

            entity.Property(e => e.Errorid).HasColumnName("errorid");
            entity.Property(e => e.Errormessage)
                .HasMaxLength(100)
                .HasColumnName("errormessage");
            entity.Property(e => e.Errortime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("errortime");
            entity.Property(e => e.Exceptiontype)
                .HasMaxLength(200)
                .HasColumnName("exceptiontype");
            entity.Property(e => e.Stacktrace)
                .HasMaxLength(100)
                .HasColumnName("stacktrace");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
