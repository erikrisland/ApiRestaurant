using ApiRestaurante.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // Fluent API

            #region Tablas
            modelBuilder.Entity<Ingrediente>().ToTable("Ingredientes");
            modelBuilder.Entity<Plato>().ToTable("Platos");
            modelBuilder.Entity<Mesa>().ToTable("Mesas");
            modelBuilder.Entity<Orden>().ToTable("Ordenes");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Ingrediente>().HasKey(i => i.Id);
            modelBuilder.Entity<Plato>().HasKey(p => p.Id);
            modelBuilder.Entity<Mesa>().HasKey(m => m.Id);
            modelBuilder.Entity<Orden>().HasKey(o => o.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Mesa)
                .WithMany(m => m.Ordenes)
                .HasForeignKey(o => o.MesaId);

            modelBuilder.Entity<Orden>()
                .HasMany(o => o.Platos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plato>()
                .HasMany(p => p.Ingredientes)
                .WithMany(i => i.Platos);
            #endregion

            #region Property Configurations

            modelBuilder.Entity<Plato>()
                .Property(p => p.Precio)
                .IsRequired();

            modelBuilder.Entity<Plato>()
                .Property(p => p.CantidadPersonas)
                .IsRequired();

            modelBuilder.Entity<Plato>()
                .Property(p => p.Categoria)
                .IsRequired();

            modelBuilder.Entity<Mesa>()
                .Property(m => m.CantidadPersonas)
                .IsRequired();

            modelBuilder.Entity<Mesa>()
                .Property(m => m.Descripcion)
                .IsRequired();

            modelBuilder.Entity<Mesa>()
                .Property(m => m.Estado)
                .IsRequired();

            modelBuilder.Entity<Orden>()
                .Property(o => o.Subtotal)
                .IsRequired();

            modelBuilder.Entity<Orden>()
                .Property(o => o.Estado)
                .IsRequired();

            #endregion

        }
    }
}