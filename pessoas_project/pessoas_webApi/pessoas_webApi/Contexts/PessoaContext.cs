using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using pessoas_webApi.Domains;

namespace pessoas_webApi.Contexts
{
    public partial class PessoaContext : DbContext
    {
        public PessoaContext()
        {
        }

        public PessoaContext(DbContextOptions<PessoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Telefone> Telefones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DSK_PHD001\\SQLEXPRESS;Initial Catalog=Pessoas;user Id=sa;pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("PK__Email__DF537710F4EFD27C");

                entity.ToTable("Email");

                entity.HasIndex(e => e.Email1, "UQ__Email__A9D10534DC8046BB")
                    .IsUnique();

                entity.Property(e => e.IdEmail).HasColumnName("idEmail");

                entity.Property(e => e.Email1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK__Email__idPessoa__3A81B327");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Pessoa__83D303D081CEAE78");

                entity.ToTable("Pessoa");

                entity.HasIndex(e => e.Cpf, "UQ__Pessoa__C1F8973185AC09E5")
                    .IsUnique();

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.IdTelefone)
                    .HasName("PK__Telefone__39C142D5ADFBF50C");

                entity.ToTable("Telefone");

                entity.Property(e => e.IdTelefone).HasColumnName("idTelefone");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.NumTelefone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numTelefone")
                    .IsFixedLength();

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK__Telefone__idPess__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
