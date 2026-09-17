using MySql.Data.MySqlClient;

public class LivroDAO
{
    private Conexao conexaoBanco;

    public LivroDAO()
    {
        conexaoBanco = new Conexao();
    }
// INSERT //
public void Cadastrar(Livro livro)
{
    using (MySqlConnection conexao = conexaoBanco.Conectar())
        {
            string sql = @"INSERT INTO livros
                        (titulo, autor, ano, preco)
                        VALUES
                        (@titulo, @autor, @ano, @preco)";

            using (MySqlCommand comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWhithValue("@titulo", livro.Titulo);
                comando.Parameters.AddWhithValue("@autor", livro.Autor);
                comando.Parameters.AddWhithValue("@ano", livro.Ano);
                comando.Parameters.AddWhithValue("@preco", livro.Preco);
                
            }
        }
}

// SELECT //
public List<Livro> Listar()
    {
        List<Livro> Livros = new List<Livro>();

        using (MySqlConnection conexao = conexaoBanco.Conectar())
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
                        Convert.ToDouble(leitor["preco"])
                    );

                    livro.Id = Convert.ToInt32(leitor["id"]);

                    LIvros.Add(livro);
                }
            }
        }

        return livros;
    }
// UPDATE //
    public void Alterar(Livro livro)
    {
        using (MySqlConnection conexao = conexaoBanco.Conectar())
        {
            string sql = @"UPDATE livros
                           SET titulo = @titulo,
                               autor = @autor,
                               ano = @ano,
                               preco = @preco,
                               quantidade = @quantidade
                           WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@id", livro.Id);
                comando.Parameters.AddWithValue("@titulo", livro.Titulo);
                comando.Parameters.AddWithValue("@autor", livro.Autor);
                comando.Parameters.AddWithValue("@ano", livro.Ano);
                comando.Parameters.AddWithValue("@preco", livro.Preco);
                comando.Parameters.AddWithValue("@quantidade", livro.Quantidade);

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Livro alterado com sucesso!");
    }

// DELETE //
    public void Excluir(int id)
    {
        using (MySqlConnection conexao = conexaoBanco.Conectar())
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
