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
            livro.cadastrarLivro();
            Console.WriteLine("Informe o CPF para logar no sistema: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Informe sua senha: ");
            string senha = Console.ReadLine();
            if(funcionario.login(cpf, senha))
            {
                Console.WriteLine("Bem vindo ao sistema!");
            }else
            {
                Console.WriteLine("Login incorreto. O sistema será encerrado.");
            }
        }
    }
}
