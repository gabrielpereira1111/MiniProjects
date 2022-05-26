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
                            idTiposUsuario = 1,
                            Nome = "Administrador"
                        },

                        new TiposUsuario()
                        {
                            idTiposUsuario = 2,
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
                            idUsuario = 1,
                            Email = "admin@email.com",
                            Senha = "0123456789",
                            IdTiposUsuario = 1
                        },
                        new Usuarios()
                        {
                            idUsuario = 2,
                            Email = "comum@email.com",
                            Senha = "0123456789",
                            IdTiposUsuario = 2
                        }
                    );
            });
            
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasIndex(x => x.Cpf).IsUnique();
                entity.HasIndex(x => x.idUsuario).IsUnique();

                entity.HasData(
                        new Clientes()
                        {
                            idCliente = 1,
                            Nome = "Administrador",
                            Cpf = "00000000000",
                            idUsuario = 1
                        },
                        new Clientes()
                        {
                            idCliente = 2,
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
                            idEmpresa = 1,
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
                            idMarca = 1,
                            Nome = "Chevrolet"
                        },
                        new Marcas()
                        {
                            idMarca = 2,
                            Nome = "Fiat"
                        }
                    );
            });

            modelBuilder.Entity<Modelos>(entity =>
            {
                entity.HasData(
                        new Modelos()
                        {
                            idModelo = 1,
                            Nome = "Argo",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 2
                        },
                        new Modelos()
                        {
                            idModelo = 2,
                            Nome = "Cronos",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 2
                        },
                        new Modelos()
                        {
                            idModelo = 3,
                            Nome = "Camaro",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 1
                        },
                        new Modelos()
                        {
                            idModelo = 4,
                            Nome = "Cruzer",
                            Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.",
                            idMarca = 1
                        }
                    );
            });

            modelBuilder.Entity<Veiculos>(entity => {
                entity.HasIndex(x => x.Placa).IsUnique();
                entity.HasData(
                        new Veiculos()
                        {
                            idVeiculo = 1,
                            idEmpresa = 1,
                            idModelo = 1,
                            Placa = "5679203"
                        },
                        new Veiculos()
                        {
                            idVeiculo = 2,
                            idEmpresa = 1,
                            idModelo = 2,
                            Placa = "6781314"
                        },
                        new Veiculos()
                        {
                            idVeiculo = 3,
                            idEmpresa = 1,
                            idModelo = 2,
                            Placa = "6570103"
                        },
                        new Veiculos()
                        {
                            idVeiculo = 4,
                            idEmpresa = 1,
                            idModelo = 4,
                            Placa = "7683029",
                        }
                    );
            });

            modelBuilder.Entity<Alugueis>(entity =>
            {
                entity.HasIndex(x => x.IdVeiculo).IsUnique();

                entity.HasData(
                        new Alugueis()
                        {
                            idAluguel = 1,
                            IdVeiculo = 1,
                            IdCliente = 2,
                            DataInicio = Convert.ToDateTime("26/05/2022"),
                            DataFim = Convert.ToDateTime("26/06/2022")
                        },
                        new Alugueis()
                        {
                            idAluguel = 2,
                            IdVeiculo = 3,
                            IdCliente = 1,
                            DataInicio = Convert.ToDateTime("28/05/2022"),
                            DataFim = Convert.ToDateTime("02/06/2022")
                        }
                    );
            }
            );
        }
    }
}
