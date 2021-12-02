using System;
using System.IO;

namespace biblioteca.Classes
{
    public class Funcionario : Pessoa
    {
        private string email;
        private string senha;
        private int tipoUsuario; //1- Adm / 2- Funcionario (ADM é um funcionario, porém apenas ADM pode adicionar novos funcionarios).
    
        public string getEmail(){
            return this.email;
        }
        public void setEmail(string email){
            this.email = email;
        }
        public string getSenha(){
            return this.senha;
        }
        public void setSenha(string senha){
            this.senha = senha;
        }
        public int getTipoUsuario(){
            return this.tipoUsuario;
        }
        public void setTipoUsuario(int tipoUsuario){
            this.tipoUsuario = tipoUsuario;
        }

        public void cadastroFuncionario()
        {
            Console.WriteLine("Informe o nome do funcionário: ");
            this.setNome(Console.ReadLine());
            Console.WriteLine("Informe o CPF do funcionário: ");
            this.setCpf(Console.ReadLine());
            Console.WriteLine("Informe o email do funcionário: ");
            this.setEmail(Console.ReadLine());
            Console.WriteLine("Informe a senha do funcionário: ");
            this.setSenha(Console.ReadLine());
            Console.WriteLine("Informe se o funcionário é um colaborador ou é um gerente(1- Gerente | 2- Colaborador) : ");
            this.setTipoUsuario(Int32.Parse(Console.ReadLine()));

            FileStream funcionarioFile = new FileStream("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swFuncionario = new StreamWriter(funcionarioFile);

            string strFunc = this.getCpf() + ";" + this.getTipoUsuario() + ";" + this.getNome() + ";" + this.getEmail() + ";" + this.getSenha();
            swFuncionario.WriteLine(strFunc);
            swFuncionario.Close();
            funcionarioFile.Close();
        }

        public bool login(string cpf, string senha)
        {
            string[] funcionarios = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt");
            
            foreach (var funcionario in funcionarios)
            {
                string[] f = funcionario.Split(";");
                if (f[0] == cpf && f[4] == senha)
                {
                    return true;
                }
            }
            return false;
        }
    }
}