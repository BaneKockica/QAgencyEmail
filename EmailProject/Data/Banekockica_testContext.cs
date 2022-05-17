using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EmailProject.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmailProject.Data
{
    public partial class Banekockica_testContext : DbContext
    {
        public Banekockica_testContext(DbContextOptions<Banekockica_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<ImportanceEmail> ImportanceEmail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.EmialId)
                    .HasName("PK__Email__153609B10C4FD34C");

                entity.Property(e => e.EmialId).HasColumnName("EmialID");

                entity.Property(e => e.CcemailAddresses)
                    .HasColumnName("CCEmailAddresses")
                    .HasMaxLength(300);

                entity.Property(e => e.EmailContent).HasMaxLength(300);

                entity.Property(e => e.FromEmailAddress).HasMaxLength(300);

                entity.Property(e => e.Subject).HasMaxLength(300);

                entity.Property(e => e.ToEmailAddress).HasMaxLength(300);

                entity.HasOne(d => d.ImportanceNavigation)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.Importance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Email__Importanc__25869641");
            });

            modelBuilder.Entity<ImportanceEmail>(entity =>
            {
                entity.Property(e => e.ImportanceEmailId).HasColumnName("ImportanceEmailID");

                entity.Property(e => e.ImportanceName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
