namespace biblioteca.Classes
{
    public class Pessoa
    {
        protected string nome;
        protected string cpf;

        public string getNome(){
            return this.nome;
        }
        public void setNome( string nome){
            this.nome = nome;
        }
        public string getCpf(){
            return this.cpf;
        }
        public void setCpf(string cpf){
            this.cpf = cpf;
        }
    }
}