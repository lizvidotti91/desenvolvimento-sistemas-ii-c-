using Microsoft.EntityFrameworkCore;

namespace moveis_planejados.Models
{
    public class MoveisPlanejadosContext : DbContext
    {
        public MoveisPlanejadosContext(DbContextOptions<MoveisPlanejadosContext> options) : base(options){}
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Movel> Moveis { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}