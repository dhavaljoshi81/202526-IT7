using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IT7BDIDemoMVCCoreWebAPPCS.Models;

public partial class It72025dbContext : DbContext
{
    public IConfiguration _conf { get; set; }
    public It72025dbContext()
    {
    }

    public It72025dbContext(DbContextOptions<It72025dbContext> options, IConfiguration configuration)
        : base(options)
    {
        _conf = configuration;
    }

    public virtual DbSet<DataLog> DataLogs { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(_conf.GetConnectionString("SQLServerLoggerDB"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataLog>(entity =>
        {
            entity.ToTable("DataLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataValue)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.ToTable("ErrorLog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ErrorValue).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
