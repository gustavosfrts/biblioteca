using System;
using System.IO;
namespace biblioteca.Classes
{
    public class Livro
    {
        private int id;
        private string nomeLivro;
        private string editora;
        private int quantidade;

        public int getId(){
            return this.id;
        }
        public void setId(int id){
            this.id = id;
        }
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

        public void cadastrarLivro()
        {
            // Pegando o ultimo ID para poder cadastrar o novo id.
            string[] livros = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\livros.txt");
            int ultimoId = 1;
            if (livros.Length > 0)
            {
                string[] livro = livros[livros.Length-1].Split(";");
                ultimoId = livros.Length > 0 ? Int32.Parse(livro[0])+1 : 1;
            }
            // Cadastro do livro de fato
            this.setId(ultimoId);
            Console.WriteLine("Informe nome do Livro: ");
            this.setNomeLivro(Console.ReadLine());
            Console.WriteLine("Informe Editora: ");
            this.setEditora(Console.ReadLine());
            Console.WriteLine("Informe Quantidade de livros:");
            this.setQuantidade(Int32.Parse(Console.ReadLine()));

            FileStream livrosFile = new FileStream("C:\\projetos\\biblioteca\\arquivos\\livros.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swLivros = new StreamWriter(livrosFile);

            string strLivro = this.getId() + ";" + this.getNomeLivro() + ";" + this.getEditora() + ";" + this.getQuantidade();
            swLivros.WriteLine(strLivro);
            swLivros.Close();
            livrosFile.Close();
        }

        public void listarLivros()
        {
            string[] livros = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\livros.txt");
            foreach (var livroConcatenado in livros)
            {
                string[] livro = livroConcatenado.Split(";");
                Console.WriteLine();
                Console.WriteLine("Id: {0}", livro[0]);
                Console.WriteLine("Nome: {0}", livro[1]);
                Console.WriteLine("Editora: {0}", livro[2]);
                Console.WriteLine("Quantidade em estoque: {0}", livro[3]);
                Console.WriteLine();
            }
        }

        public void editarLivro(int idLivro, string nomeLivro, string nomeEditora, int quantidadeLivrosAdicionado)
        {
            string[] livros = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\livros.txt");
            string[] livrosAtualizado = new string[livros.Length];

            for (int i = 0; i <= livros.Length-1; i++)
            {
                string[] livro = livros[i].Split(";");
                if (Int32.Parse(livro[0]) == idLivro)
                {
                    quantidadeLivrosAdicionado = quantidadeLivrosAdicionado + Int32.Parse(livro[3]);
                    livrosAtualizado[i] = idLivro + ";" + (nomeLivro == "" ? livro[1] : nomeLivro) + ";" + (nomeEditora == "" ? livro[2] : nomeEditora) + ";" + quantidadeLivrosAdicionado;
                }
                else
                {
                    livrosAtualizado[i] = livros[i];
                }
                
            File.WriteAllText("C:\\projetos\\biblioteca\\arquivos\\livros.txt", "");
            FileStream livroArquivo = new FileStream("C:\\projetos\\biblioteca\\arquivos\\livros.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swLivro = new StreamWriter(livroArquivo);
            foreach (var l in livrosAtualizado)
            {    
                swLivro.WriteLine(l);
            }
            swLivro.Close();
            livroArquivo.Close();
            }
        }

        public static void listarLivrosDisponiveis()
        {
            string[] livros = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\livros.txt");
            foreach (var livroConcatenado in livros)
            {
                string[] livro = livroConcatenado.Split(";");
                if (Int32.Parse(livro[3]) > 0)
                {    
                    Console.WriteLine();
                    Console.WriteLine("Id: {0}", livro[0]);
                    Console.WriteLine("Nome: {0}", livro[1]);
                    Console.WriteLine("Editora: {0}", livro[2]);
                    Console.WriteLine("Quantidade em estoque: {0}", livro[3]);
                    Console.WriteLine();
                }
            }
        }

        public static bool livroDisponivel(int livroId)     
        {
            string[] livros = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\livros.txt");
            foreach (var livroConcatenado in livros)
            {
                string[] livro = livroConcatenado.Split(";");
                if (Int32.Parse(livro[3]) > 0)
                {    
                    if (Int32.Parse(livro[0]) == livroId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void pegarLivro(int livroId)
        {
            string[] livros = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\livros.txt");
            string[] livrosAtualizado = new string[livros.Length];

            for (int i = 0; i <= livros.Length-1; i++)
            {
                string[] livro = livros[i].Split(";");
                if (Int32.Parse(livro[0]) == livroId)
                {
                    livro[3] = (Int32.Parse(livro[3]) - 1).ToString();
                    livrosAtualizado[i] = livro[0] + ";" + livro[1] + ";" + livro[2] + ";" + livro[3];
                }
                else
                {
                    livrosAtualizado[i] = livros[i];
                }
                
            File.WriteAllText("C:\\projetos\\biblioteca\\arquivos\\livros.txt", "");
            FileStream livroArquivo = new FileStream("C:\\projetos\\biblioteca\\arquivos\\livros.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swLivro = new StreamWriter(livroArquivo);
            foreach (var l in livrosAtualizado)
            {    
                swLivro.WriteLine(l);
            }
            swLivro.Close();
            livroArquivo.Close();
            }
        }

        public static void devolverLivro(int livroId)
        {
            string[] livros = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\livros.txt");
            string[] livrosAtualizado = new string[livros.Length];

            for (int i = 0; i <= livros.Length-1; i++)
            {
                string[] livro = livros[i].Split(";");
                if (Int32.Parse(livro[0]) == livroId)
                {
                    livro[3] = (Int32.Parse(livro[3]) + 1).ToString();
                    livrosAtualizado[i] = livro[0] + ";" + livro[1] + ";" + livro[2] + ";" + livro[3];
                }
                else
                {
                    livrosAtualizado[i] = livros[i];
                }
                
            }
            File.WriteAllText("C:\\projetos\\biblioteca\\arquivos\\livros.txt", "");
            FileStream livroArquivo = new FileStream("C:\\projetos\\biblioteca\\arquivos\\livros.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swLivro = new StreamWriter(livroArquivo);
            foreach (var l in livrosAtualizado)
            {    
                swLivro.WriteLine(l);
            }
            swLivro.Close();
            livroArquivo.Close();
        }
    }
}