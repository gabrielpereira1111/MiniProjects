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

        public virtual DbSet<Cnh> Cnhs { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<Telefone> Telefones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Data Source=DSK_PHD001\\SQLEXPRESS; Initial Catalog=Pessoas; user Id=sa; pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cnh>(entity =>
            {
                entity.HasKey(e => e.IdCnh)
                    .HasName("PK__CNH__0FA0C566F55768A7");

                entity.ToTable("CNH");

                entity.Property(e => e.IdCnh).HasColumnName("IdCNH");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Cnhs)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK__CNH__IdPessoa__3E52440B");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("PK__Emails__E80F8BD4214E0045");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK__Emails__IdPessoa__3B75D760");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__Pessoas__7061465DF413346D");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.IdTelefone)
                    .HasName("PK__Telefone__9B8AC7A9FC44E394");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK__Telefones__IdPes__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
