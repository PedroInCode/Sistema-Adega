using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using sistema_Adega.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Banco;

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

    private readonly string stringConnection = "Server=10.91.45.46;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Configura o EF Core para utilizar o MySql/MariaDB com autodetecção de versão
        optionsBuilder.UseMySql(
            stringConnection,
            ServerVersion.AutoDetect(stringConnection)
            );
    }
}
