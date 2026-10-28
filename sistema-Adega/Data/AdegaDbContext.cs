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
    public DbSet<FormaPagamento> FormasPagamento { get; set; } = null!;
    public DbSet<Funcionario> Funcionarios { get; set; } = null!;
    public DbSet<ItemCompra> ItensCompra { get; set; } = null!;
    public DbSet<MarcaProduto> MarcaProdutos { get; set; } = null!;
    public DbSet<Produto> Produtos { get; set; } = null!;


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
}
