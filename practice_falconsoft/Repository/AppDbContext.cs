using Microsoft.EntityFrameworkCore;
using practice_falconsoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
        {

        }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalle { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido()
                {
                    Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    Nombre = "Pedro",
                    Apellido = "Cavallo",
                    Fecha = new DateTime(2021, 4, 1)                    
                },
                new Pedido()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Fecha = new DateTime(2021, 4, 1)
                });

            modelBuilder.Entity<Producto>().HasData(
                   new Producto
                   {
                       Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                       Nombre = "Mesa ratona",
                       Precio = 400,
                       Stock = 2
                   },
                   new Producto
                   {
                       Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                       Nombre = "Silla madera",
                       Precio = 200,
                       Stock = 4
                   },
                   new Producto
                   {
                       Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                       Nombre = "Estantes",
                       Precio = 150,
                       Stock = 13
                   }
                   );

            modelBuilder.Entity<PedidoDetalle>().HasData(
                   new PedidoDetalle
                   {
                       Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                       PedidoId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                       ProductoId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")

                   },
                   new PedidoDetalle
                   {
                       Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6c"),
                       PedidoId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                       ProductoId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   },
                   new PedidoDetalle
                   {
                       Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6d"),
                       PedidoId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                       ProductoId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   }
                   );

            modelBuilder.Entity<Usuario>().HasData(
                   new Usuario
                   {
                       Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6e"),
                       User = "falcon",
                       Password = "a84571394b5e99fe70aae39ece25f844acbaf83479e27f39a30732e092b19677"

                   }
                   );

            base.OnModelCreating(modelBuilder);
        }

    }
}
