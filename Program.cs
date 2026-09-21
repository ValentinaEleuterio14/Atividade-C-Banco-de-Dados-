using System;
using MySqlConnector;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("       SISTEMA DE BIBLIOTECA");
            Console.WriteLine("=================================");
            Console.WriteLine("1 - Testar conexão");
            Console.WriteLine("2 - Cadastrar livro");
            Console.WriteLine("3 - Listar livros");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("=================================");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    TestarConexao();
                    break;

                case "2":
                    CadastrarLivro();
                    break;

                case "3":
                    ListarLivros();
                    break;

                case "4":
                    Console.WriteLine("Encerrando o sistema...");
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void TestarConexao()
    {
        try
        {
            MySqlConnection conexao = SistemaLivro.Conectar();

            if (conexao != null)
            {
                Console.WriteLine("Banco de dados conectado!");
                conexao.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }

    static void CadastrarLivro()
    {
        Console.WriteLine("\n--- CADASTRAR LIVRO ---");

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        Console.Write("Ano de publicação: ");
        int ano = int.Parse(Console.ReadLine());

        try
        {
            using (MySqlConnection conexao = SistemaLivro.Conectar())
            {
                string sql = @"
                    INSERT INTO livros (nome, autor, ano_publicacao)
                    VALUES (@titulo, @autor, @ano)";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@titulo", titulo);
                    comando.Parameters.AddWithValue("@autor", autor);
                    comando.Parameters.AddWithValue("@ano", ano);

                    comando.ExecuteNonQuery();

                    Console.WriteLine("\nLivro cadastrado com sucesso!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao cadastrar livro: " + ex.Message);
        }
    }

    static void ListarLivros()
    {
        Console.WriteLine("\n--- LIVROS CADASTRADOS ---");

        try
        {
            using (MySqlConnection conexao = SistemaLivro.Conectar())
            {
                string sql = "SELECT id, nome, autor, ano_publicacao FROM livros";

                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                using (MySqlDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("ID: " + leitor["id"]);
                        Console.WriteLine("Livro: " + leitor["titulo"]);
                        Console.WriteLine("Autor: " + leitor["autor"]);
                        Console.WriteLine("Ano: " + leitor["ano_publicacao"]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar livros: " + ex.Message);
        }
    }
}