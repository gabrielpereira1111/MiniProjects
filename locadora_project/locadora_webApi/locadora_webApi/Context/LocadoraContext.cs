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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DSK_PHD001\SQLEXPRESS;Initial Catalog=NewLocadora;user Id=sa;pwd=123456");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasIndex(x => x.Nome).IsUnique();

                entity.HasData(
                        new TiposUsuario()
                        {
                            Nome = "Administrador"
                        },

                        new TiposUsuario()
                        {
                            Nome = "Comum"
                        }
                    );
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(x => x.Email).IsUnique();

                entity.HasData(
                        new Usuarios()
                        {
                            Email = "admin@email.com",
                            Senha = "1234",
                            IdTipoUsuario = 1
                        },
                        new Usuarios()
                        {
                            Email = "comum@email.com",
                            Senha = "1234",
                            IdTipoUsuario = 2
                        }
                    );
            });
            
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasIndex(x => x.Cpf).IsUnique();
                entity.HasIndex(x => x.idUsuario).IsUnique();
                entity.HasIndex(x => x.Usuario).IsUnique();

                entity.HasData(
                        new Clientes()
                        {
                            Nome = "Administrador",
                            Cpf = "00000000000",
                            idUsuario = 1
                        },
                        new Clientes()
                        {
                            Nome = "Comum",
                            Cpf = "47612984835",
                            idUsuario = 2
                        }
                    );
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasIndex(x => x.Nome).IsUnique();
                entity.HasData(
                        new Empresas()
                        {
                            Nome = "Locadora de Carros"
                        }
                    );
            });

            modelBuilder.Entity<Marcas>(entity =>
            {
                entity.HasIndex(x => x.Nome).IsUnique();
                entity.HasData(
                        new Marcas()
                        {
                            Nome = "Chevrolet"
                        },
                        new Marcas()
                        {
                            Nome = "Fiat"
                        }
                    );
            });

            modelBuilder.Entity<Modelos>(entity =>
            {
                entity.HasData(
                        new Modelos()
                        {
                            Nome = "Argo",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 2
                        },
                        new Modelos()
                        {
                            Nome = "Cronos",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 2
                        },
                        new Modelos()
                        {
                            Nome = "Camaro",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 1
                        },
                        new Modelos()
                        {
                            Nome = "Cruzer",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 1
                        }
                    );
            });
        }
    }
}
