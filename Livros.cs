public class Livro
{
    public int Id {get; set; }
    public string Título {get; set; }
    public string autor {get; set; }
    public string Editora {get; set; }
    public double Preco {get; set; }
    public int Ano {get; set; }

    public Livro(string título, string autor, int ano, double preco)
    {
        Título = título;
        autor = autor;
        Ano = ano;
        Preco = preco;
    }

    public override string ToString()
    {
        return $"ID: {Id} | Título: {Título} | Autor: {Autor} | Ano: {Ano} | Preço: R$ {Preco:F2}";
    }
}