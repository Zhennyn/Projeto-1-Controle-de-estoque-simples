using System;
using System.IO;

class Program {
    struct Livro {
        public string Nome;
        public double Preco;
        public string Autor;
        public string Genero;
        public int Estoque;
    }

    static Livro[] livros = new Livro[100];
    static int totalLivros = 0;

    static void Main(string[] args) {
        int resposta;
        
        do {
            Console.WriteLine("[1] Novo\n[2] Listar produtos\n[3] Remover produtos\n[4] Entrada Estoque\n[5] Saída Estoque\n[0] Sair");
            resposta = int.Parse(Console.ReadLine());

            switch (resposta) {
                case 1:
                    AdicionarLivro();
                    break;
                case 2:
                    ListarLivros();
                    break;
                case 3:
                    RemoverLivro();
                    break;
                case 4:
                    AtualizarEstoque(true);
                    break;
                case 5:
                    AtualizarEstoque(false);
                    break;
                case 0:
                    Console.WriteLine("Programa encerrado");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (resposta != 0);
    }

    static void AdicionarLivro() {
        Console.WriteLine("Informe o nome do livro:");
        string nomeLivro = Console.ReadLine();

        Console.WriteLine("Informe o preço do livro:");
        double precoLivro = double.Parse(Console.ReadLine());

        Console.WriteLine("Informe o autor do livro:");
        string autorLivro = Console.ReadLine();

        Console.WriteLine("Informe o Gênero:");
        string generoLivro = Console.ReadLine();

        Console.WriteLine("Informe a quantidade em estoque:");
        int estoqueAtual = int.Parse(Console.ReadLine());

        Livro novoLivro = new Livro {
            Nome = nomeLivro,
            Preco = precoLivro,
            Autor = autorLivro,
            Genero = generoLivro,
            Estoque = estoqueAtual
        };

        livros[totalLivros] = novoLivro;
        totalLivros++;

        Console.WriteLine("O livro foi adicionado.");
    }

    static void ListarLivros() {
    Console.WriteLine("Lista de Livros e Estoque:");

    for (int i = 0; i < totalLivros; i++) {
        Console.WriteLine($"Livro: {livros[i].Nome} ({livros[i].Preco:C}) - Estoque: {livros[i].Estoque}");
    }
}


    static void RemoverLivro() {
        Console.WriteLine("Informe o nome do livro que deseja remover:");
        string nomeLivroRemover = Console.ReadLine();

        bool livroEncontrado = false;

        for (int i = 0; i < totalLivros; i++) {
            if (livros[i].Nome == nomeLivroRemover) {
                livroEncontrado = true;

                for (int j = i; j < totalLivros - 1; j++) {
                    livros[j] = livros[j + 1];
                }

                totalLivros--;

                Console.WriteLine("Livro removido.");
                break;
            }
        }

        if (!livroEncontrado) {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void AtualizarEstoque(bool entrada) {
        Console.WriteLine("Informe o nome do livro:");
        string nomeLivro = Console.ReadLine();

        for (int i = 0; i < totalLivros; i++) {
            if (livros[i].Nome == nomeLivro) {
                Console.WriteLine($"Quantidade {(entrada ? "adicionada" : "retirada")} ao estoque:");
                int quantidadeAlterada = int.Parse(Console.ReadLine());

                if (!entrada && quantidadeAlterada > livros[i].Estoque) {
                    Console.WriteLine("Não é possível retirar mais unidades do que o estoque atual.");
                } else {
                    livros[i].Estoque += (entrada ? quantidadeAlterada : -quantidadeAlterada);
                    Console.WriteLine($"A quantidade atualizada de unidades é {livros[i].Estoque}");
                }
                return;
            }
        }

        Console.WriteLine("Livro não encontrado.");
    }
}