LivroDAO livroDAO = new LivroDAO();

while (true)
{
    Console.WriteLine("\n--------- SISTEMA DE LIVROS ---------");
    Console.WriteLine("1 - Cadastrar livro");
    Console.WriteLine("2 - Listar livros");
    Console.WriteLine("3 - Alterar livro");
    Console.WriteLine("4 - Excluir livro");
    Console.WriteLine("5 - Sair");
    Console.WriteLine("O que deseja fazer?: ");

    string opcao = Console.ReadLine();

    if(opcao == "1")
    {
        Console.WriteLine("Título: ");
        string titulo = Console.ReadLine();

        Console.WriteLine("Autor: ");
        string autor = Console.ReadLine();

        Console.WriteLine("Ano: ");
        int ano = int.Parse(Console.ReadLine());

        Console.WriteLine("Preço: ");
        double preco = double.Parse(Console.ReadLine());

        livro livro = new livro(
            título,
            autor,
            ano,
            preco
        );

        livroDAO.Cadastrar(livro);
    }
    else if (opcao == "2")
    {
        livroDAO.Listar();
    }
    else if (opcao == "5")
    { 
        Console.WriteLine("Programa encerrando...");
        break;
    }
}