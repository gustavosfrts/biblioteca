using System;
using System.IO;
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
        public void cadastrarLivro(){

            Console.WriteLine("Informe nome do Livro: ");
            this.setNomeLivro(Console.ReadLine());
            Console.WriteLine("Informe Editora: ");
            this.setEditora(Console.ReadLine());
            Console.WriteLine("Informe Quantidade de livros:");
            this.setQuantidade(Int32.Parse(Console.ReadLine()));

            FileStream livrosFile = new FileStream("C:\\projetos\\biblioteca\\arquivos\\livros.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swLivros = new StreamWriter(livrosFile);

            string strLivro = this.getNomeLivro() + ";" + this.getEditora() + ";" + this.getQuantidade();
            swLivros.WriteLine(strLivro);
            swLivros.Close();
            livrosFile.Close();
        }
             
    }
}