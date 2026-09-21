using MySqlConnector;

public class LivroDAO
{
    // CADASTRAR LIVRO
    public void Cadastrar(Livro livro)
    {
        using (MySqlConnection? conexao = SistemaLivro.Conectar())
        {
            string sql = @"INSERT INTO livros
                           (titulo, autor, ano, preco)
                           VALUES
                           (@titulo, @autor, @ano, @preco)";

            using (MySqlCommand comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@titulo", livro.Titulo);
                comando.Parameters.AddWithValue("@autor", livro.Autor);
                comando.Parameters.AddWithValue("@ano", livro.Ano);
                comando.Parameters.AddWithValue("@preco", livro.Preco);

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Livro cadastrado com sucesso!");
    }

    // LISTAR LIVROS
    public List<Livro> Listar()
    {
        List<Livro> livros = new List<Livro>();

        using (MySqlConnection? conexao = SistemaLivro.Conectar())
        {
            string sql = "SELECT * FROM livros";

            using (MySqlCommand comando = new MySqlCommand(sql, conexao))
            using (MySqlDataReader leitor = comando.ExecuteReader())
            {
                while (leitor.Read())
                {
                    Livro livro = new Livro(
                        leitor["titulo"].ToString(),
                        leitor["autor"].ToString(),
                        Convert.ToInt32(leitor["ano"]),
                        leitor["editora"].ToString(),
                        Convert.ToDouble(leitor["preco"])
                    );

                    livro.Id = Convert.ToInt32(leitor["id"]);

                    livros.Add(livro);
                }
            }
        }

        return livros;
    }

    // ALTERAR LIVRO
    public void Alterar(Livro livro)
    {
        using (MySqlConnection? conexao = SistemaLivro.Conectar())
        {
            string sql = @"UPDATE livros
                           SET titulo = @titulo,
                               autor = @autor,
                               ano = @ano,
                               preco = @preco
                           WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@id", livro.Id);
                comando.Parameters.AddWithValue("@titulo", livro.Titulo);
                comando.Parameters.AddWithValue("@autor", livro.Autor);
                comando.Parameters.AddWithValue("@ano", livro.Ano);
                comando.Parameters.AddWithValue("@preco", livro.Preco);

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Livro alterado com sucesso!");
    }

    // EXCLUIR LIVRO
    public void Excluir(int id)
    {
        using (MySqlConnection? conexao = SistemaLivro.Conectar())
        {
            string sql = "DELETE FROM livros WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Livro excluído com sucesso!");
    }
}
