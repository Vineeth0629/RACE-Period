using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class EmployeDBContext : DbContext
    {
        public EmployeDBContext()
        {
        }

        public EmployeDBContext(DbContextOptions<EmployeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employe> Employes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MOBACK\\MSSQLSERVER01;Database=EmployeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employe");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.Empage).HasColumnName("empage");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Empname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
