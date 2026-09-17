LivroDAO livroDAO = new LivroDAO();

// MENU PRINCIPAL //
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

// CADASTRAR LIVRO //
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
            titulo,
            autor,
            ano,
            preco
        );

        livroDAO.Cadastrar(livro);
    }

// LISTAR LIVROS //
    else if (opcao == "2")
    {
        List<Livro> livros = livroDAO.Listar();

        Console.WriteLine("\n========= LIVROS CADATRADOS =========");

        foreach (Livro livro in livros)
        {
            Console.WriteLine(livro);
        }
    }

// ALTERAÇÃO DO LIVRO //
    else if (opcao == "3")
    {
        Console.WriteLine("\nDigite o ID do livro: "); // Tem que rever esse WriteLine ai 
        int id = int.Parse(Console.ReadLine());

        Console.Write("Novo título: ");
        string titulo = Console.ReadLine();

        Console.Write("Novo autor: ");
        string autor = Console.ReadLine();

        Console.Write("Novo ano: ");
        int ano = int.Parse(Console.ReadLine());
        
        Console.Write("Novo preço: ");
        double preco = double.Parse(Console.ReadLine());

        Livro livro = new Livro(
            titulo,
            autor,
            ano,
            preco

        );

        livro.Id = id;

        livroDAO.Alterar(livro);

    }

// EXCLUSÃO DO LIVRO //
    else if (opcao == "4")
    {
        Console.Write("\nDigite o ID do livro que deseja exclur: ");
        int id = int.Parse(Console.ReadLine);

        livroDAO.Excluir(id);
    }

    else if (opcao == "5")
    {
        Console.WriteLine("Programa encerrando...");
        break;
    }

    else
    {
        Console.WriteLine("Opção inválida!");
    }


}