using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IT7ADIDemoMVCCoreAppCS.Models;

public partial class It72025dbContext : DbContext
{
    private IConfiguration _conf;
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

        => optionsBuilder.UseSqlServer(_conf.GetConnectionString("SQLServerLogger"));

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
