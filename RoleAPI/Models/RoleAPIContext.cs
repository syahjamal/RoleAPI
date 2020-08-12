using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace RoleAPI.Models
{
    public partial class RoleAPIContext : DbContext
    {
        public RoleAPIContext()
        {
        }

        public RoleAPIContext(DbContextOptions<RoleAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Label)
                    .HasColumnName("label")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("role_menu");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
