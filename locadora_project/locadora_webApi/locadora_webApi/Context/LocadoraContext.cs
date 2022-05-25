using locadora_webApi.Domains;
using Microsoft.EntityFrameworkCore;

namespace locadora_webApi.Context
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Alugueis> Alugueis { get; set; } = null!;
        public DbSet<Clientes> Clientes { get; set; } = null!;
        public DbSet<Empresas> Empresas { get; set; } = null!;
        public DbSet<Marcas> Marcas { get; set; } = null!;
        public DbSet<Modelos> Modelos { get; set; } = null!;
        public DbSet<TiposUsuario> TiposUsuario { get; set; } = null!;
        public DbSet<Usuarios> Usuarios { get; set; } = null!;
        public DbSet<Veiculos> Veiculos { get; set; } = null!;

    }
}
