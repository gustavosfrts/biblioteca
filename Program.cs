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
            Cliente cliente = new Cliente();

            Console.WriteLine("Informe o CPF para logar no sistema: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Informe sua senha: ");
            string senha = Console.ReadLine();

            if(funcionario.login(cpf, senha))
            {
                funcionario = funcionario.retornaFuncionario(cpf);
                int ops = 999;
                bool aux;

                bool loop = true;
                while (loop)
                {    
                    switch (ops)
                    {
                        case 1:
                            livro.cadastrarLivro();
                            Console.WriteLine("Livro cadastrado com sucesso.");
                            ops = 999;
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            break;
                        case 2:
                            livro.listarLivros();
                            Console.WriteLine();
                            Console.WriteLine("Informe o ID do livro que deseja editar(DIGITE 0 para cancelar a operação): ");
                            int id = Int32.Parse(Console.ReadLine());
                            if (id == 0) { ops = 999; break; }
                            Console.WriteLine("Informe o novo nome do livro (aperte ENTER caso nao queira alterar o nome): ");
                            string nomeLivro = Console.ReadLine();
                            Console.WriteLine("Informe o novo nome da editora do livro (aperte ENTER caso nao queira alterar o nome): ");
                            string nomeEditora = Console.ReadLine();
                            Console.WriteLine("Informe quantos livros foram adicionados (DIGITE 0 para não alterar a quantidade): ");
                            int quantidadeLivros = Int32.Parse(Console.ReadLine());
                            livro.editarLivro(id, nomeLivro, nomeEditora, quantidadeLivros);
                            Console.WriteLine("Livro editado com sucesso!");
                            ops = 999;
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            break;
                        case 3:
                            if(funcionario.cadastroFuncionario())
                            {
                                Console.WriteLine("Funcionário cadastrado com sucesso!");
                                break;
                            }
                            ops = 999;
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            break;
                        case 4:
                            if(funcionario.edicaoFuncionario())
                            {
                                Console.WriteLine("Funcionário editado com sucesso!");
                            }
                            ops = 999;
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            break;
                        case 5:
                            if (cliente.cadastroCliente())
                            {
                                Console.WriteLine("Cliente cadastrado com sucesso!");
                            }
                            ops = 999;
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Informe o CPF do cliente: ");
                            string cpfCliente = Console.ReadLine();
                            if (!Cliente.encontrarCliente(cpfCliente))
                            {
                                Console.WriteLine("Não foi possível encontrar este CPF em nossa base de dados. Por favor, tente novamente mais tarde.");
                                break;
                            }
                            Livro.listarLivrosDisponiveis();
                            Console.WriteLine("Informe o ID do livro que deseja pegar emprestado: ");
                            int livroId = Int32.Parse(Console.ReadLine());
                            if (!Livro.livroDisponivel(livroId))
                            {
                                Console.WriteLine("Livro incorreto. Por favor, tente novamente mais tarde.");
                                break;
                            }
                            Emprestimo.cadastroEmprestimo(funcionario.getCpf(), cpfCliente, livroId);
                            
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            ops = 999;
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Informe o CPF do cliente: ");
                            string cpfDevolucao = Console.ReadLine();
                            if(Emprestimo.devolverLivro(cpfDevolucao))
                            {
                                Console.WriteLine("Devolução realizada com sucesso.");
                                Console.WriteLine("Pressione qualquer botão para continuar...");
                                Console.ReadLine();
                                ops = 999;
                                break;
                            }
                            Console.WriteLine("Não foi possível realizar a devolução do livro. Tente novamente mais tarde.");
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            ops = 999;
                            break;
                        case 8:
                            Console.WriteLine("Saindo do sistema...");
                            loop = false;
                            break;
                        case 999:
                            // Menu de escolha de opções
                            Console.Clear();
                            Console.WriteLine("Bem vindo ao sistema!");
                            Console.WriteLine("Escolha uma das opções a baixo:");
                            Console.WriteLine("1. Cadastrar novo livro");
                            Console.WriteLine("2. Editar livro existente");
                            Console.WriteLine("3. Cadastrar novo colaborador");
                            Console.WriteLine("4. Editar colaborador");
                            Console.WriteLine("5. Cadastrar cliente");
                            Console.WriteLine("6. Realizar empréstimo");
                            Console.WriteLine("7. Devolver livro");
                            Console.WriteLine("8. Sair");
                            aux = Int32.TryParse(Console.ReadLine(), out ops);
                            if (!aux){ ops = 0; }
                            break;
                        default:
                            Console.WriteLine("Opção incorreta. Por favor, tente novamente!");
                            aux = Int32.TryParse(Console.ReadLine(), out ops);
                            if (!aux){ ops = 0; }
                            Console.WriteLine("Pressione qualquer botão para continuar...");
                            Console.ReadLine();
                            break;
                    }
                }
                
            }else
            {
                Console.WriteLine("Login incorreto. O sistema será encerrado.");
            }
        }
    }
}
