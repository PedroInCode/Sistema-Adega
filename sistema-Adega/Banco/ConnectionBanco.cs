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

    public static int ExecutarComando(MySqlCommand cmd)
    {
        //O bloco using garante que a conexão será automaticamente fechada e liberada da memoria ao final do bloco
        
        //Cria a conexão utilizando a variavel de ambiente
        using(var conexao = new MySqlConnection(stringConnection))
        {
            //Vinculação: Diz ao comando SQL qual conexão ele deve executar
            cmd.Connection = conexao;

            //Tratamento de erros: Inicia um bloco de tentativa para proteger o programa de falhas abruptas
            try
            {
                //Abertura de conexão: Estabelece efetivamente a comunicação com o servidor MySql
                conexao.Open();

                //Executa o comando SQL (Insert, Update ou Delete) no banco de dados
                //Retorna um número inteiro correspondente ao total de linhas que foram modificadas
                return cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error: Problema com o banco de dados: {ex.Message}");
                return -1;
            }
        }
    }
}
