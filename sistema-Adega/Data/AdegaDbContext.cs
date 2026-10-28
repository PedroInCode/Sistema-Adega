using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sistema_Adega.Model;

namespace sistema_Adega.Data;

public class AdegaDbContext : DbContext
{
    //Cada DbSet representa uma tabela no banco de dados
    // Mapeamento de todas as tabelas do seu sistema com base na sua pasta Models
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Compra> Compras { get; set; } = null!;
    public DbSet<CupomDesconto> CupomDescontos { get; set; } = null!;
    public DbSet<Endereco> Enderecos { get; set; } = null!;
    public DbSet<Entrega> Entregas { get; set; } = null!;
    public DbSet<Funcionario> Funcionarios { get; set; } = null!;
    public DbSet<ItemCompra> ItensCompra { get; set; } = null!;
    public DbSet<MarcaProduto> MarcaProdutos { get; set; } = null!;
    public DbSet<Produto> Produtos { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<AdegaDbContext>()
                .Build();

            string stringConnection =
                configuration.GetConnectionString("Adega")
                ?? throw new InvalidOperationException(
                    "String de conexão 'Adega' não configurada.");

            optionsBuilder.UseMySql(
                stringConnection,
                ServerVersion.AutoDetect(stringConnection)
            );
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração para guardar Enums como string (VARCHAR) no banco
        modelBuilder.Entity<Cliente>().Property(c => c.TipoDocumento).HasConversion<string>();
        modelBuilder.Entity<Funcionario>().Property(f => f.TipoDocumento).HasConversion<string>();
        modelBuilder.Entity<Funcionario>().Property(f => f.TipoCargo).HasConversion<string>();

        modelBuilder.Entity<Compra>().Property(c => c.Status).HasConversion<string>();
        modelBuilder.Entity<Compra>().Property(c => c.TipoCompra).HasConversion<string>();
        modelBuilder.Entity<Compra>().Property(c => c.FormaPagamento).HasConversion<string>();

        modelBuilder.Entity<Entrega>().Property(e => e.StatusEntrega).HasConversion<string>();
        modelBuilder.Entity<Entrega>().Property(e => e.TipoFrete).HasConversion<string>();
    }
}
