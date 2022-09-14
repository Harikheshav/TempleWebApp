using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TempleWebApp.Models;

namespace TempleWebApp.Models
{
    public partial class TempleContext : DbContext
    {
        public TempleContext()
        {
        }

        public TempleContext(DbContextOptions<TempleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnDhanBkng> AnDhanBkngs { get; set; } = null!;
        public virtual DbSet<ConHallBkng> ConHallBkngs { get; set; } = null!;
        public virtual DbSet<FnHallBkng> FnHallBkngs { get; set; } = null!;
        public virtual DbSet<Pooja> Poojas { get; set; } = null!;
        public virtual DbSet<PoojaBkng> PoojaBkngs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Temple;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnDhanBkng>(entity =>
            {
                entity.HasKey(e => e.Bkid)
                    .HasName("PK__AnDhanBk__51399146ECC8712F");

                entity.ToTable("AnDhanBkng");

                entity.Property(e => e.Bkid).HasColumnName("bkid");

                entity.Property(e => e.Det)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("det");

                entity.Property(e => e.Edt)
                    .HasColumnType("datetime")
                    .HasColumnName("edt");

                entity.Property(e => e.Sdt)
                    .HasColumnType("datetime")
                    .HasColumnName("sdt");
            });

            modelBuilder.Entity<ConHallBkng>(entity =>
            {
                entity.HasKey(e => e.Bkid)
                    .HasName("PK__ConHallB__5139914619C3DC21");

                entity.ToTable("ConHallBkng");

                entity.Property(e => e.Bkid).HasColumnName("bkid");

                entity.Property(e => e.Det)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("det");

                entity.Property(e => e.Edt)
                    .HasColumnType("datetime")
                    .HasColumnName("edt");

                entity.Property(e => e.Sdt)
                    .HasColumnType("datetime")
                    .HasColumnName("sdt");
            });

            modelBuilder.Entity<FnHallBkng>(entity =>
            {
                entity.HasKey(e => e.Bkid)
                    .HasName("PK__FnHallBk__51399146440EF955");

                entity.ToTable("FnHallBkng");

                entity.Property(e => e.Bkid).HasColumnName("bkid");

                entity.Property(e => e.Det)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("det");

                entity.Property(e => e.Edt)
                    .HasColumnType("datetime")
                    .HasColumnName("edt");

                entity.Property(e => e.Sdt)
                    .HasColumnType("datetime")
                    .HasColumnName("sdt");
            });

            modelBuilder.Entity<Pooja>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Pooja__DD37D91A97661682");

                entity.ToTable("Pooja");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Details)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("details");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PoojaBkng>(entity =>
            {
                entity.HasKey(e => e.Bkid)
                    .HasName("PK__PoojaBkn__513991463D622C19");

                entity.ToTable("PoojaBkng");

                entity.Property(e => e.Bkid).HasColumnName("bkid");

                entity.Property(e => e.Det)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("det");

                entity.Property(e => e.Edt)
                    .HasColumnType("datetime")
                    .HasColumnName("edt");

                entity.Property(e => e.Sdt)
                    .HasColumnType("datetime")
                    .HasColumnName("sdt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<TempleWebApp.Models.SlotBkng>? SlotBkng { get; set; }
    }
}
