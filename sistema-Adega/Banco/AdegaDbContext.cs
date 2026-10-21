using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using sistema_Adega.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Banco;

internal class AdegaDbContext : DbContext
{
    //Cada DbSet representa uma tabela no banco de dados
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
