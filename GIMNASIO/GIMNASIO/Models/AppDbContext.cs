using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GIMNASIO.Models
{
    public class AppDbContext : IdentityDbContext<Cliente>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDGIMNASIO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            //Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDGIMNASIO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False base de datos local
            //Server=tcp:gimnasiodbserver.database.windows.net,1433;Initial Catalog=GIMNASIO_db;Persist Security Info=False;User ID=jonathan;Password=jonY_2205;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; bd en la nube
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Membresia>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Mantencion>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Entrenamiento>()
               .HasOne(p => p.Cliente)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Categoria> tblCategorias { get; set; }

        public DbSet<Estado> tblEstados { get; set; }

        public DbSet<Producto> tblProductos { get; set; }

        public DbSet<CarroItem> tblCarroItem { get; set; }

        public DbSet<MetodoPago> tblMetodoPago { get; set; }

        public DbSet<MetodoPagoMembresia> tblMetodoPagoMembresia { get; set; }
        public DbSet<TipoMembresia> tblTipoMembresia { get; set; }
        public DbSet<EstadoMembresia> tblEstadoMembresia { get; set; }

        public DbSet<Membresia> tblMembresia { get; set; }

        public DbSet<PedidoEstado> tblPedidoEstado { get; set; }
        public DbSet<Pedido> tblPedido { get; set; }

        public DbSet<PedidoDetalle> tblPedidoDetalle { get; set; }


        //se agrega tablas de entrenamiento

        public DbSet<EntrenamientoZona> tblEntrenamientoZona { get; set; }
        public DbSet<EntrenamientoEstado> tblEntrenamientoEstado { get; set; }
        public DbSet<EntrenamientoCategoria> tblEntrenamientoCategoria { get; set; }
        public DbSet<Entrenamiento> tblEntrenamiento { get; set; }

        public DbSet<EntrenamientoUsuario> tblEntrenamientoUsuario { get; set; }

        public DbSet<AvanceCliente> tblAvanceCliente { get; set; }

        //maquinaria

        public DbSet<EstadoMaquinaria> tblEstadoMaquinaria { get; set; }
        public DbSet<TipoMaquinaria> tblTipoMaquinaria { get; set; }
        public DbSet<Maquinaria> tblMaquinaria { get; set; }

        //mantencion

        public DbSet<EstadoMantencion> tblEstadoMantencion { get; set; }
        public DbSet<Mantencion> tblMantencion { get; set; }







    }
}
