namespace biblioteca.Classes
{
    public class Livro
    {
        private string nomeLivro;
        private string editora;
        private int quantidade;

        public string getNomeLivro(){
            return this.nomeLivro;
        }
        public void setNomeLivro(string nomeLivro){
            this.nomeLivro = nomeLivro;
        }
        public string getEditora(){
            return this.editora;
        }
        public void setEditora(string editora){
            this.editora = editora;
        }
        public int getQuantidade(){
            return this.quantidade;
        }
        public void setQuantidade(int quantidade){
            this.quantidade = quantidade;
        }
    }
}