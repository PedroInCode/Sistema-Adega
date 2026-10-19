using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_Adega.Banco;

internal static class ConnectionBanco
{
    private static string stringConnection = "Server=10.91.45.46;Port=3306;Database=padaria_bd;Uid=admin;Pwd=12345678";

    public static void ConnectAndTest()
    {
        using(var connection = new MySqlConnection(stringConnection))
        {
            try
            {
                Console.WriteLine("Tentendo conectar ao banco de dados...");
                connection.Open();

                using(var command = new MySqlCommand("SELECT VERSION();", connection))
                {
                    string? version = command.ExecuteScalar()?.ToString();
                    Console.WriteLine($"Versão do MariaDb: {version}");
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error: Não foi possível se conectar ao banco de dados!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
