namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entidades;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.PruebaCoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.PruebaCoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var clientes = new List<Cliente>();
            clientes.AddRange(new Cliente[] {
                new Cliente{ Nombre="Aquiles Toruño González",Codigo="281-200391-0008P"},
                new Cliente{ Nombre="Isaac Alberto Medrano Lanzas",Codigo="IAML"},
                new Cliente{ Nombre="Marvin Lenín Morales Calderón",Codigo="MLMC"},
                new Cliente{ Nombre="Rafael Arfazad García Fernández",Codigo="RAGF"}
            });

            clientes.ForEach(c =>
            {
                context.Clientes.AddOrUpdate(x => x.Codigo, c);
            });

            var productos = new List<Producto>();
            productos.AddRange(new Producto[] {
                new Producto{ Nombre="Audifonos",Codigo="ADFN",Precio=280},
                new Producto{ Nombre="Teclado",Codigo="TCLD",Precio=decimal.Parse("205.50")},
                new Producto{ Nombre="Monitor",Codigo="MNTR",Precio=1000},
                new Producto{ Nombre="UPS",Codigo="UPS",Precio=decimal.Parse("311.50")}
            });

            productos.ForEach(p =>
            {
                context.Productos.AddOrUpdate(x => x.Codigo, p);
            });

            context.SaveChanges();

            var primeraFactura = new Factura
            {
                ClienteId = 1,
                Codigo = "V1",
                Fecha = DateTime.Now,
                Total = 971,
                DetalleFacturas = new List<DetalleFactura> {
                    new DetalleFactura{
                        ProductoId=1,
                        Precio=280,
                        Cantidad=2,
                        Total=280*2
                    },
                    new DetalleFactura{
                        ProductoId=2,
                        Precio=decimal.Parse("205.50"),
                        Cantidad=3,
                        Total=decimal.Parse("205.50")*2
                    }
                }
            };

            var segundaFactura = new Factura
            {
                ClienteId = 2,
                Codigo = "V2",
                Fecha = DateTime.Now,
                Total = 971,
                DetalleFacturas = new List<DetalleFactura> {
                    new DetalleFactura{
                        ProductoId=3,
                        Precio=280,
                        Cantidad=2,
                        Total=280*2
                    },
                    new DetalleFactura{
                        ProductoId=4,
                        Precio=decimal.Parse("205.50"),
                        Cantidad=3,
                        Total=decimal.Parse("205.50")*2
                    },
                    new DetalleFactura{
                        ProductoId=2,
                        Precio=decimal.Parse("205.50"),
                        Cantidad=3,
                        Total=decimal.Parse("205.50")*2
                    }
                }
            };

            context.Facturas.AddOrUpdate(x => x.Codigo, primeraFactura);
            context.Facturas.AddOrUpdate(x => x.Codigo, segundaFactura);
        }
    }
}
