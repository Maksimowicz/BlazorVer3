using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorVer3.Models
{
    public partial class PAI_DBContext : DbContext
    {
        public PAI_DBContext()
        {
        }

        public PAI_DBContext(DbContextOptions<PAI_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GoogleMapsPin> GoogleMapsPins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PAI_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoogleMapsPin>(entity =>
            {
                entity.HasKey(e => e.PinName)
                    .HasName("PK__GoogleMa__C7C1AC44F32E7686");

                entity.Property(e => e.PinName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AddressStr)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
