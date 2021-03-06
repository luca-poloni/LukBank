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

        public virtual DbSet<CadastrosApps> CadastrosApps { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Contas> Contas { get; set; }
        public virtual DbSet<Pagamentos> Pagamentos { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<Tipostransacoes> Tipostransacoes { get; set; }
        public virtual DbSet<Transacoes> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;DataBase=LukBank;Uid=root;Pwd=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CadastrosApps>(entity =>
            {
                entity.ToTable("cadastrosapps");

                entity.HasIndex(e => e.Conta)
                    .HasName("Conta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Conta).HasColumnType("int(11)");

                entity.Property(e => e.DataInserido)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnType("varchar(400)");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnType("varchar(400)");

                entity.HasOne(d => d.ContaNavigation)
                    .WithMany(p => p.CadastrosApps)
                    .HasForeignKey(d => d.Conta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cadastrosapps_ibfk_1");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("clientes");

                entity.HasIndex(e => e.Conta)
                    .HasName("Conta");

                entity.HasIndex(e => e.Pessoa)
                    .HasName("Pessoa");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.Conta).HasColumnType("int(11)");

                entity.Property(e => e.DataInserido)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Pessoa).HasColumnType("int(11)");

                entity.HasOne(d => d.ContaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Conta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clientes_ibfk_2");

                entity.HasOne(d => d.PessoaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Pessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clientes_ibfk_1");
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
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.DataInserido)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Numero).HasColumnType("int(11)");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TipoConta)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Pagamentos>(entity =>
            {
                entity.ToTable("pagamentos");

                entity.HasIndex(e => e.Conta)
                    .HasName("Conta");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CodigoBarra).HasColumnType("int(11)");

                entity.Property(e => e.Conta).HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Valor).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.ContaNavigation)
                    .WithMany(p => p.Pagamentos)
                    .HasForeignKey(d => d.Conta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pagamentos_ibfk_1");
            });

            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.ToTable("pessoas");

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
                    .HasColumnType("varchar(400)");

                entity.Property(e => e.TipoPessoa).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Tipostransacoes>(entity =>
            {
                entity.ToTable("tipostransacoes");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Transacoes>(entity =>
            {
                entity.ToTable("transacoes");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ContaDestino).HasColumnType("int(11)");

                entity.Property(e => e.ContaRemetente).HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.TipoTransacao).HasColumnType("int(11)");

                entity.Property(e => e.Valor).HasColumnType("decimal(10,0)");
            });
        }
    }
}
