using System;
using biblioteca.Classes;

namespace biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Login biblioteca-------");

            Funcionario funcionario = new Funcionario();
            Livro livro = new Livro();

            Console.WriteLine("Informe o CPF para logar no sistema: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Informe sua senha: ");
            string senha = Console.ReadLine();

            if(funcionario.login(cpf, senha))
            {
                funcionario = funcionario.retornaFuncionario(cpf);
                // Menu de escolha de opções
                Console.WriteLine("Bem vindo ao sistema!");
                Console.WriteLine("Escolha uma das opções a baixo:");
                Console.WriteLine("1. Cadastrar novo livro");
                Console.WriteLine("2. Editar livro existente");
                Console.WriteLine("3. Cadastrar novo colaborador");
                Console.WriteLine("4. Editar colaborador");
                Console.WriteLine("5. Cadastrar cliente");
                Console.WriteLine("6. Realizar empréstimo");
                Console.WriteLine("7. Verificar empréstimos ativos");
                int ops;
                bool aux = Int32.TryParse(Console.ReadLine(), out ops);
                if (!aux){ ops = 0; }

                switch (ops)
                {
                    case 1:
                        livro.cadastrarLivro();
                        break;
                    case 2:
                        livro.listarLivros();
                        Console.WriteLine();
                        Console.WriteLine("Informe o ID do livro que deseja editar(DIGITE 0 para cancelar a operação): ");
                        int id = Int32.Parse(Console.ReadLine());
                        if (id == 0) { break; }
                        Console.WriteLine("Informe o novo nome do livro (aperte ENTER caso nao queira alterar o nome): ");
                        string nomeLivro = Console.ReadLine();
                        Console.WriteLine("Informe o novo nome da editora do livro (aperte ENTER caso nao queira alterar o nome): ");
                        string nomeEditora = Console.ReadLine();
                        Console.WriteLine("Informe quantos livros foram adicionados (DIGITE 0 para não alterar a quantidade): ");
                        int quantidadeLivros = Int32.Parse(Console.ReadLine());
                        livro.editarLivro(id, nomeLivro, nomeEditora, quantidadeLivros);
                        Console.WriteLine("Livro editado com sucesso!");
                        break;
                    default:
                        break;
                }
                
            }else
            {
                Console.WriteLine("Login incorreto. O sistema será encerrado.");
            }
        }
    }
}
