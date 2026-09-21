public class Livro
{
    public int Id {get; set; }
    public string Titulo {get; set; }
    public string Autor {get; set; }
    public string Editora {get; set; }
    public double Preco {get; set; }
    public int Ano {get; set; }

    public Livro(string título, string autor, int ano, string editora, double preco)
    {
        Titulo = título;
        Autor = autor;
        Ano = ano;
        Editora = editora;
        Preco = preco;
    }

    public override string ToString()
    {
        return $"ID: {Id} | Título: {Titulo} | Autor: {Autor} | Ano: {Ano} | Editora: {Editora} | Preço: R$ {Preco:F2}";
    }
}