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

        public bool cadastroFuncionario()
        {
            Funcionario novoFuncionario = new Funcionario();
            Console.WriteLine("Informe o nome do funcionário: ");
            novoFuncionario.setNome(Console.ReadLine());
            Console.WriteLine("Informe o CPF do funcionário: ");
            novoFuncionario.setCpf(Console.ReadLine());
            Console.WriteLine("Informe o email do funcionário: ");
            novoFuncionario.setEmail(Console.ReadLine());
            Console.WriteLine("Informe a senha do funcionário: ");
            novoFuncionario.setSenha(Console.ReadLine());
            Console.WriteLine("Informe se o funcionário é um colaborador ou é um gerente(1- Gerente | 2- Colaborador) : ");
            novoFuncionario.setTipoUsuario(Int32.Parse(Console.ReadLine()));
            // Verificando se o colaborador possui permissão para cadastrar o funcionario como adm
            if (novoFuncionario.getTipoUsuario() == 1 && this.getTipoUsuario() == 2)
            {
                Console.WriteLine("Você não possui permissão para realizar este cadastro. Solicite ao administrador de seu sistema para realizar o cadastro.");
                return false;
            }
            // Verificando se já existe o email ou CPF cadastrado na base de dados.
            string[] funcionarios = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt");
            foreach (var funcionario in funcionarios)
            {
                string[] f = funcionario.Split(";");
                if (f[0] == novoFuncionario.getCpf() || f[3] == novoFuncionario.getEmail())
                {
                    Console.WriteLine("Email ou CPF já cadastrado.");
                    return false;
                }
            }

            FileStream funcionarioFile = new FileStream("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swFuncionario = new StreamWriter(funcionarioFile);

            string strFunc = novoFuncionario.getCpf() + ";" + novoFuncionario.getTipoUsuario() + ";" + novoFuncionario.getNome() + ";" + novoFuncionario.getEmail() + ";" + novoFuncionario.getSenha();
            swFuncionario.WriteLine(strFunc);
            swFuncionario.Close();
            funcionarioFile.Close();
            return true;
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

        public Funcionario retornaFuncionario(string cpf)
        {
            string[] funcionarios = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt");
            Funcionario func = new Funcionario();

            foreach (var funcionario in funcionarios)
            {
                string[] f = funcionario.Split(";");
                if (f[0] == cpf)
                {
                    func.setCpf(f[0]);
                    func.setTipoUsuario(Int32.Parse(f[1]));
                    func.setNome(f[2]);
                    func.setEmail(f[3]);
                    func.setSenha(f[4]);
                }
            }
            return func;
        }
        public static bool validaFuncionario(Funcionario funcionario)
        // Método valida se é adm ou não. Caso seja Administrador, retorna TRUE, caso contrario, retorna FALSE.
        {
            if (funcionario.getTipoUsuario() == 1)
            {
                return true;
            }
            return false;
        }
        public bool edicaoFuncionario()
        {
            Console.WriteLine("Informe o CPF do Funcionario que deseja editar: ");
            string cpf = Console.ReadLine();
            Funcionario funcionarioEditar = new Funcionario();
            // Verifica se o funcionario esta tentando se editar (para mudar a permissao para ADM por ex.)
            if (cpf == this.getCpf())
            {
                Console.WriteLine("Não é possível editar o seu próprio cadastro.");
                return false;
            }
            // Valida se o cpf informado realmente existe nos cadastros ativos
            funcionarioEditar = this.retornaFuncionario(cpf);
            if (funcionarioEditar.getNome() == null)
            {
                Console.WriteLine("CPF Incorreto. Por favor, tente novamente com um CPF que já esteja cadastrado em nosso sistema.");
                return false;
            }

            Console.WriteLine("Informe o nome do funcionário (caso nao queira editar o nome pressione ENTER): ");
            string nome = Console.ReadLine();
            funcionarioEditar.setNome(nome == "" ? funcionarioEditar.getNome() : nome);
            Console.WriteLine("Informe o email do funcionário (caso nao queira editar o email pressione ENTER): ");
            string email = Console.ReadLine();
            funcionarioEditar.setEmail(email == "" ? funcionarioEditar.getEmail() : email);
            Console.WriteLine("Informe a senha antiga funcionário: ");
            if (Console.ReadLine() != funcionarioEditar.getSenha())
            {
                Console.WriteLine("Senhas não conferem. Operação cancelada por segurança do sistema.");
                return false;
            }
            Console.WriteLine("Informe a nova senha do funcionário (caso nao queira editar a senha pressione ENTER): ");
            string senha = Console.ReadLine();
            funcionarioEditar.setSenha(senha == "" ? funcionarioEditar.getSenha() : senha);
            // Valida se o funcionario logado é ADM ou não para poder mostrar a opção de alterar o tipo de cadastro.
            if (this.getTipoUsuario() == 1)
            {    
                Console.WriteLine("Informe se o funcionário é um colaborador ou é um gerente(1- Gerente | 2- Colaborador)");
                Console.WriteLine("(caso nao queira editar o tipo de usuario pressione ENTER): ");
                string tipo = Console.ReadLine();
                if (tipo != "")
                {
                    funcionarioEditar.setTipoUsuario(Int32.Parse(tipo));
                }
            }

            string[] funcionarios = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt");
            string[] funcionariosAtualizado = new string[funcionarios.Length];

            for (int i = 0; i <= funcionarios.Length-1; i++)
            {
                string[] funcionario = funcionarios[i].Split(";");
                if (funcionario[0] == funcionarioEditar.getCpf())
                {
                    funcionariosAtualizado[i] = funcionarioEditar.getCpf() + ";" + funcionarioEditar.getTipoUsuario() + ";" + funcionarioEditar.getNome() + ";" + funcionarioEditar.getEmail() + ";" + funcionarioEditar.getSenha();
                }
                else
                {
                    funcionariosAtualizado[i] = funcionarios[i];
                }
                
            File.WriteAllText("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt", "");
            FileStream funcionarioArquivo = new FileStream("C:\\projetos\\biblioteca\\arquivos\\funcionarios.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swFuncionario = new StreamWriter(funcionarioArquivo);
            foreach (var l in funcionariosAtualizado)
            {    
                swFuncionario.WriteLine(l);
            }
            swFuncionario.Close();
            funcionarioArquivo.Close();
            }
            return true;
        }

    }
}