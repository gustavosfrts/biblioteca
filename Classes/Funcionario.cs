namespace biblioteca.Classes
{
    public class Funcionario : Pessoa
    {
        private string email;
        private string senha;
        private int tipoUsuario; //1- Adm / 2- Funcionario (ADM é um funcionario, porém apenas ADM pode adicionar novos funcionarios).
    }
}