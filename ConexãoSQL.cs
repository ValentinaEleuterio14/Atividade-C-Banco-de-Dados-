using System;
using MySqlConnector;
 
class Program
{
    static void Main()
    {
        // 1. String de conexão
        string conexaoString = "Server=localhost;Database=MeuBanco;Trusted_Connection=True;TrustServerCertificate=True;";
 
        // 2. Criar e abrir a conexão usando 'using' para fechar automaticamente
        using (SqlConnection conexao = new SqlConnection(conexaoString))
        {
            try
            {
                conexao.Open();
                Console.WriteLine("Conexão realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
            }
        }
    }
}