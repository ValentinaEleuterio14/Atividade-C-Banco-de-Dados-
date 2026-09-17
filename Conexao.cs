using System;
using MySqlConnector;
 
class Program
{
    static void Main()
    {
        string conexaoString = "Server=localhost;Database=MeuBanco;Trusted_Connection=True;TrustServerCertificate=True;";
 
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

