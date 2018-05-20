using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PruebaCoreContext : DbContext
    {
        public PruebaCoreContext() : base("name=PruebaCoreBD")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().Property(p => p.Precio).HasPrecision(18, 3);
            modelBuilder.Entity<Factura>().Property(f => f.Total).HasPrecision(18, 3);
            modelBuilder.Entity<DetalleFactura>().Property(df => df.Precio).HasPrecision(18, 3);
            modelBuilder.Entity<DetalleFactura>().Property(df => df.Total).HasPrecision(18, 3);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
