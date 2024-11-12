using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_damsDigitalTwinDB.models;

public partial class DamsDigitaltwinsDbContext : DbContext
{
    public DamsDigitaltwinsDbContext()
    {
    }

    public DamsDigitaltwinsDbContext(DbContextOptions<DamsDigitaltwinsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<SensorDatum> SensorData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dams-digitaltwins-db;Username=postgres;Password=r00t");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Sensors_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Measurement).HasColumnName("measurement");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Units).HasColumnName("units");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");
            entity.Property(e => e.Z).HasColumnName("z");
        });

        modelBuilder.Entity<SensorDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SensorData_pkey");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.DateTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateTime");
            entity.Property(e => e.SensorId).HasColumnName("sensorId");
            entity.Property(e => e.SeriesName).HasColumnName("seriesName");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Sensor).WithMany(p => p.SensorData)
                .HasForeignKey(d => d.SensorId)
                .HasConstraintName("FK_SensorData_Sensors");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
