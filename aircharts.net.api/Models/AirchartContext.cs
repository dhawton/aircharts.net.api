using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aircharts.net.api.Models
{
    public partial class AirchartContext : DbContext
    {
        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<Charts> Charts { get; set; }

        public AirchartContext(DbContextOptions<AirchartContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airports>(entity =>
            {
                entity.ToTable("airports");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(4);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasColumnName("country_id")
                    .HasMaxLength(2);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Elevation)
                    .HasColumnName("elevation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fir)
                    .HasColumnName("fir")
                    .HasMaxLength(4);

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(10,6)");

                entity.Property(e => e.Lon)
                    .HasColumnName("lon")
                    .HasColumnType("decimal(10,6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");
            });

            modelBuilder.Entity<Charts>(entity =>
            {
                entity.ToTable("charts");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100);

                entity.Property(e => e.Airportname)
                    .IsRequired()
                    .HasColumnName("airportname")
                    .HasMaxLength(255);

                entity.Property(e => e.Chartname)
                    .IsRequired()
                    .HasColumnName("chartname")
                    .HasMaxLength(255);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(2);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasMaxLength(2);

                entity.Property(e => e.Iata)
                    .HasColumnName("iata")
                    .HasMaxLength(4);

                entity.Property(e => e.Icao)
                    .IsRequired()
                    .HasColumnName("icao")
                    .HasMaxLength(4);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("mediumtext");
            });
        }
    }
}
