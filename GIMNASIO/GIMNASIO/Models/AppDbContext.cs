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
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = BDGIMNASIO; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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

    }
}
