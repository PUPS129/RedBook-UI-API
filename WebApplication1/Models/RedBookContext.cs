using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class RedBookContext : DbContext
    {
        

        public RedBookContext(DbContextOptions<RedBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ClassA> ClassA { get; set; }
        public virtual DbSet<Kingdoms> Kingdoms { get; set; }
        public virtual DbSet<SubClass> SubClass { get; set; }
        public virtual DbSet<Thiss> Thiss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer($"Server=DESKTOP-F6MVFN7\\SQLEXPRESS; Database=RedBook;Trusted_Connection=True;");
            }
        }

        // 322-09
        // (localdb)\MSSQLLocalDB
        // DESKTOP-F6MVFN7//SQLEXPRESS

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ClassA>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.KingdomId).HasColumnName("KingdomID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Kingdom)
                    .WithMany(p => p.ClassA)
                    .HasForeignKey(d => d.KingdomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassA_Kingdoms");
            });

            modelBuilder.Entity<Kingdoms>(entity =>
            {
                entity.HasKey(e => e.KingdomId);

                entity.Property(e => e.KingdomId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SubClass>(entity =>
            {
                entity.Property(e => e.SubClassId).HasColumnName("subClassID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SubClass)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_SubClass_ClassA");
            });

            modelBuilder.Entity<Thiss>(entity =>
            {
                entity.HasKey(e => e.ThisId);

                entity.Property(e => e.ThisId).HasColumnName("ThisID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Descc).HasColumnName("descc");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SubClassId).HasColumnName("SubClassID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Thiss)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Thiss_Category");

                entity.HasOne(d => d.SubClass)
                    .WithMany(p => p.Thiss)
                    .HasForeignKey(d => d.SubClassId)
                    .HasConstraintName("FK_Thiss_SubClass");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
