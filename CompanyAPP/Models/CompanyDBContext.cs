using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyAPP.Models
{
    public partial class CompanyDBContext : DbContext
    {
        public CompanyDBContext()
        {
        }

        public CompanyDBContext(DbContextOptions<CompanyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=CompanyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PkCustomerId);

                entity.Property(e => e.PkCustomerId).HasColumnName("PK_CustomerID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CellNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkStatusId).HasColumnName("FK_StatusID");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("Postal Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkStatus)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.FkStatusId)
                    .HasConstraintName("FK__Customer__FK_Sta__29572725");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.PkNoteId);

                entity.Property(e => e.PkNoteId).HasColumnName("PK_NoteID");

                entity.Property(e => e.FkCustomerId).HasColumnName("FK_CustomerID");

                entity.Property(e => e.Note1)
                    .HasColumnName("Note")
                    .HasMaxLength(500);

                entity.HasOne(d => d.FkCustomer)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.FkCustomerId)
                    .HasConstraintName("FK__Note__FK_Custome__2C3393D0");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.PkStatusId);

                entity.Property(e => e.PkStatusId).HasColumnName("PK_StatusID");

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasMaxLength(50);
            });
        }
    }
}
