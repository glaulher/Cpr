using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cpr.Domain.LivroCaixa;

namespace Cpr.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //as entidades relacionadas no modelo de entidades são carregadas 
        // somente quando forem realmente necessárias.
            optionsBuilder.UseLazyLoadingProxies();
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mudar o nome para requerido e máximo de 50 caracter no bd
            modelBuilder.Entity<Categoria>().Property(p => p.CategEntradaSaida).IsRequired().HasMaxLength(50);
            //Alterando o nome da tabela 
            // modelBuilder.Entity<Categoria>().ToTable("Categoria");
            //Mudar o nome para requerido e máximo de 50 caracter no bd
            modelBuilder.Entity<LivroCaixa>().Property(p => p.Descricao).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<LivroCaixa>().Property(p => p.Valor).HasColumnType("decimal(8,2)");
            // liga o migration ao identity
            base.OnModelCreating(modelBuilder);
        }
        //mapeia as entidades
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<LivroCaixa> LivroCaixa { get; set; }
    }
}
