using FiscalControl.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiscalControl.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cartao> Cartao { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<MetaEconomica> MetaEconomica { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definindo a relação entre Usuario e Cartao
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Cartoes)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Definindo a relação entre Usuario e Receita
            modelBuilder.Entity<Receita>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.ReceitasEntrada)
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            // Definindo a relação entre Usuario e Transacao
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Transacoes)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Definindo a relação entre Usuario e MetaEconomica
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.MetasEconomicas)
                .WithOne(me => me.Usuario)
                .HasForeignKey(me => me.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Definindo a relação entre Usuario e ContaBancaria
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.ContasBancarias)
                .WithOne(cb => cb.Usuario)
                .HasForeignKey(cb => cb.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Definindo a relação entre Usuario e Despesa
            modelBuilder.Entity<Despesa>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Despesas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configurações para o tipo decimal
            modelBuilder.Entity<ContaBancaria>()
                .Property(c => c.Saldo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Despesa>()
                .Property(d => d.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MetaEconomica>()
                .Property(m => m.ValorMeta)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Receita>()
                .Property(r => r.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transacao>()
                .Property(t => t.Valor)
                .HasColumnType("decimal(18,2)");
        }

    }
}
