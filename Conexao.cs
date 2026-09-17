using System;
using MySqlConnector;
 
class Program
{
    static void Main()
    {
        string conexaoString = "Server=localhost;Database=biblioteca;UID=root; PSD=Senac2026";
 
        using (var conexao = new MySqlConnection(conexaoString))
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

