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

        
    }
}