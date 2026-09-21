using System;
using System.Linq.Expressions;
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
            Console.WriteLine("0 - Testar conexão");
            Console.WriteLine("1 - Cadastrar livro");
            Console.WriteLine("2 - Listar livros");
            Console.WriteLine("3 - Alterar Livro");
            Console.WriteLine("4 - Excluir livro");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("=================================");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    TestarConexao();
                    break;

                case "1":
                    CadastrarLivro();
                    break;

                case "2":
                    ListarLivros();
                    break;

                case "3":
                    AlterarLivro();
                    break;

                case "4":
                    ExcluirLivro();
                    break;

                case "5":
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
                    INSERT INTO livros (titulo, autor, ano_publicacao)
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
                string sql = "SELECT id, titulo, autor, ano_publicacao FROM livros";

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

    static void AlterarLivro()
    {
        Console.WriteLine("\n--- ALTERAR LIVRO ---");

        Console.WriteLine("Digite o ID do livro que deseja alterar:");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Novo título:");
        string titulo = Console.ReadLine();


        Console.Write("Novo autor:");
        string autor = Console.ReadLine();

        Console.Write("Novo ano de publicação:");
        int ano = int.Parse(Console.ReadLine());

        try
        {
            using (MySqlConnection conexao = SistemaLivro.Conectar())
            {
                string sql = @"
                    UPDATE livros
                    SET titulo = @titulo, autor = @autor, ano_publicacao = @ano
                    where id = @id";

                    using (MySqlCommand command = new MySqlCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@titulo", titulo);
                    command.Parameters.AddWithValue("@autor", autor);
                    command.Parameters.AddWithValue("@ano", ano);
                    command.Parameters.AddWithValue("@id", id);

                    int linhasAfetadas = command.ExecuteNonQuery();


                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Livro alterado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum livro encontrado com o ID fornecido.");
                    }
                }
            }
        }    
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao alterar livro: " + ex.Message);
        }
            
        }

        static void ExcluirLivro()
    {
        Console.WriteLine("\n--- EXCLUIR LIVRO ---");

        Console.WriteLine("Digite o ID do livro  que deseja excluir:");
        int id = int.Parse(Console.ReadLine());

        try
        {
            using (MySqlConnection conexao = SistemaLivro.Conectar())
            {
                string sql = "DELETE FROM livros WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(sql, conexao))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int linhasAfetadas = command.ExecuteNonQuery();
                
                if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Livro excluído com sucesso!");
                    }

                    else
                    {
                        Console.WriteLine("Nenhum livro encontrado com o ID fornecido.");

                    }
                }
            }
        }
        catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir livro: " + ex.Message);
            }
                
        }
    }


   
    

