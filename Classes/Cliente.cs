using System;
using System.IO;
namespace biblioteca.Classes
{
    public class Cliente : Pessoa
    {
        private string endereco;
        private string telefoneContato;

        public string getEndereco(){
            return this.endereco;
        }
        public void setEndereco(string endereco){
            this.endereco = endereco;
        }
        public string getTelefoneContato(){
            return this.telefoneContato;
        }
        public void setTelefoneContato(string telefoneContato){
            this.telefoneContato = telefoneContato;
        }

        public bool cadastroCliente()
        {
            Console.WriteLine("Informe o nome do cliente: ");
            this.setNome(Console.ReadLine());
            Console.WriteLine("Informe o endereço do cliente: ");
            this.setEndereco(Console.ReadLine());
            Console.WriteLine("Informe o telefone do cliente: ");
            this.setTelefoneContato(Console.ReadLine());
            Console.WriteLine("Informe o CPF do cliente: ");
            this.setCpf(Console.ReadLine());
            
            // Verificando se já existe o CPF cadastrado na base de dados.
            string[] clientes = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\clientes.txt");
            foreach (var cliente in clientes)
            {
                string[] c = cliente.Split(";");
                if (c[0] == this.getCpf())
                {
                    Console.WriteLine("CPF já cadastrado.");
                    return false;
                }
            }

            FileStream clienteFile = new FileStream("C:\\projetos\\biblioteca\\arquivos\\clientes.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swCliente = new StreamWriter(clienteFile);

            string strFunc = this.getCpf() + ";" + this.getTelefoneContato() + ";" + this.getNome() + ";" + this.getEndereco();
            swCliente.WriteLine(strFunc);
            swCliente.Close();
            clienteFile.Close();
            return true;
        }

        public static bool encontrarCliente(string cpf)
        {
            string[] clientes = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\clientes.txt");
            foreach (var cliente in clientes)
            {
                string[] c = cliente.Split(";");
                if (c[0] == cpf)
                {
                    return true;
                }
            }

            return false;
        }
    }
}