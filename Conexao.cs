using MySqlConnector;
 
class SistemaLivro
{
    public static MySqlConnection? Conectar()
{
    string conexaoString = "Server=localhost;Database=biblioteca;User ID=root;Password=Senac2026";

    MySqlConnection conexao = new MySqlConnection(conexaoString);

    try
    {
        conexao.Open();
        Console.WriteLine("Conexão realizada com sucesso!");
        return conexao;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao conectar: " + ex.Message);
        return null;
    }
}
}

