using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<PasswordReset> PasswordResets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database= CTRL_Testing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.ToTable("PasswordReset");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password).HasMaxLength(25);

                entity.Property(e => e.ResetCode)
                    .HasMaxLength(25)
                    .HasColumnName("Reset_code");

                entity.Property(e => e.ResetCodeSent).HasColumnName("Reset_code_sent");

                entity.Property(e => e.ResetCodeTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Reset_code_timestamp");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("User_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
