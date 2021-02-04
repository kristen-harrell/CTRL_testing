using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testing_ctrl_portal.Models
{
    public partial class CTRL_TestingContext : DbContext
    {
        public CTRL_TestingContext()
        {
        }

        public CTRL_TestingContext(DbContextOptions<CTRL_TestingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PasswordReset> PasswordReset { get; set; }
        public virtual DbSet<PersistCode> PersistCode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password).HasMaxLength(25);

                entity.Property(e => e.ResetCode)
                    .HasColumnName("Reset_code")
                    .HasMaxLength(25);

                entity.Property(e => e.ResetCodeSent).HasColumnName("Reset_code_sent");

                entity.Property(e => e.ResetCodeTimestamp)
                    .HasColumnName("Reset_code_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("User_Email")
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PersistCode>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Expiration).HasColumnType("datetime");

                entity.Property(e => e.ResetCode).HasMaxLength(6);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
