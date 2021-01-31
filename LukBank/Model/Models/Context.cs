using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LukBank.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CadastroApp> CadastroApp { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Contas> Contas { get; set; }
        public virtual DbSet<Pagamentos> Pagamentos { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<Tipotransacoes> Tipotransacoes { get; set; }
        public virtual DbSet<Transferencias> Transferencias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;DataBase=LukBank;Uid=developer;Pwd=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CadastroApp>(entity =>
            {
                entity.ToTable("cadastroapp");

                entity.HasIndex(e => e.Conta)
                    .HasName("FK_ContaApp");

                entity.HasIndex(e => e.Senha)
                    .HasName("Senha")
                    .IsUnique();

                entity.HasIndex(e => e.Usuario)
                    .HasName("Usuario")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Conta).HasColumnType("int(11)");

                entity.Property(e => e.DataInserido)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.ContaNavigation)
                    .WithMany(p => p.Cadastroapp)
                    .HasForeignKey(d => d.Conta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContaApp");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("clientes");

                entity.HasIndex(e => e.Conta)
                    .HasName("FK_Conta");

                entity.HasIndex(e => e.Pessoa)
                    .HasName("FK_Pessoa");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ativo)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Conta).HasColumnType("int(11)");

                entity.Property(e => e.DataInserido)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Pessoa).HasColumnType("int(11)");

                entity.HasOne(d => d.ContaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Conta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conta");

                entity.HasOne(d => d.PessoaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Pessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pessoa");
            });

            modelBuilder.Entity<Contas>(entity =>
            {
                entity.ToTable("contas");

                entity.HasIndex(e => e.Numero)
                    .HasName("Numero")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Agencia).HasColumnType("int(11)");

                entity.Property(e => e.Ativo)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DataInserido)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Numero).HasColumnType("int(11)");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TipoConta)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Pagamentos>(entity =>
            {
                entity.ToTable("pagamentos");

                entity.HasIndex(e => e.CodigoBarra)
                    .HasName("CodigoBarra")
                    .IsUnique();

                entity.HasIndex(e => e.Conta)
                    .HasName("FK_ContaPagamentos");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CodigoBarra)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Conta).HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Valor).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.ContaNavigation)
                    .WithMany(p => p.Pagamentos)
                    .HasForeignKey(d => d.Conta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContaPagamentos");
            });

            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.ToTable("pessoas");

                entity.HasIndex(e => e.CpfCnpj)
                    .HasName("CpfCnpj")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CpfCnpj)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.DataInserido)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(600)");

                entity.Property(e => e.TipoPessoa).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Tipotransacoes>(entity =>
            {
                entity.ToTable("tipotransacoes");

                entity.HasIndex(e => e.Nome)
                    .HasName("Nome")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ativo)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Transferencias>(entity =>
            {
                entity.ToTable("transferencias");

                entity.HasIndex(e => e.ContaDestinataria)
                    .HasName("FK_ContaDestinataria");

                entity.HasIndex(e => e.ContaRemetente)
                    .HasName("FK_ContaRemetente");

                entity.HasIndex(e => e.TipoTransacao)
                    .HasName("FK_TipoTransacao");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ContaDestinataria).HasColumnType("int(11)");

                entity.Property(e => e.ContaRemetente).HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.TipoTransacao).HasColumnType("int(11)");

                entity.Property(e => e.Valor).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.ContaDestinatariaNavigation)
                    .WithMany(p => p.TransferenciasContaDestinatariaNavigation)
                    .HasForeignKey(d => d.ContaDestinataria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContaDestinataria");

                entity.HasOne(d => d.ContaRemetenteNavigation)
                    .WithMany(p => p.TransferenciasContaRemetenteNavigation)
                    .HasForeignKey(d => d.ContaRemetente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContaRemetente");

                entity.HasOne(d => d.TipoTransacaoNavigation)
                    .WithMany(p => p.Transferencias)
                    .HasForeignKey(d => d.TipoTransacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoTransacao");
            });
        }
    }
}
