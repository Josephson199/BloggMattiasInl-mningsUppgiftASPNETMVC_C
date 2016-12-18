using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.Models
{
    public partial class MattiasBlogContext : DbContext
    {
        public virtual DbSet<BlogPost> BlogPost { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=LAPTOP-8HO4BK3G\SQLEXPRESS;Database=MattiasBlog;Trusted_Connection=True;");
        //}

        public MattiasBlogContext(DbContextOptions<MattiasBlogContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.HeadLine).HasMaxLength(50);

                entity.Property(e => e.TextBody).HasMaxLength(2000);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BlogPost)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__BlogPost__Catego__25869641");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}