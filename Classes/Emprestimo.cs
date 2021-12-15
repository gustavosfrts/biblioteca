using System;
using System.IO;

namespace biblioteca.Classes
{
    public class Emprestimo
    {
        private DateTime dataEmprestimo;
        private DateTime dataEntregaPrevista;
        private DateTime dataEntrega;
        private string cpfResposavelEmprestimo;
        private string cpfCliente;
        private bool atraso;
        private float taxaAtraso;
        private int idLivro;
        private bool emprestimoStatus;

        public DateTime getDataEmprestimo(){
            return this.dataEmprestimo;
        }
        public void setDataEmprestimo(DateTime dataEmprestimo){
            this.dataEmprestimo = dataEmprestimo;
        }
        public DateTime getDataEntregaPrevista(){
            return this.dataEntregaPrevista;
        }
        public void setDataEntregaPrevista(DateTime dataEntregaPrevista){
            this.dataEntregaPrevista = dataEntregaPrevista;
        }
        public DateTime getDataEntrega(){
            return this.dataEntrega;
        }
        public void setDataEntrega(DateTime dataEntrega){
            this.dataEntrega = dataEntrega;
        }
        public string getCpfResponsavelEmprestimo(){
            return this.cpfResposavelEmprestimo;
        }
        public void setCpfResponsavelEmprestimo(string cpfResposavelEmprestimo){
            this.cpfResposavelEmprestimo = cpfResposavelEmprestimo;
        }
        public string getCpfCliente(){
            return this.cpfCliente;
        }
        public void setCpfCliente(string cpfCliente){
            this.cpfCliente = cpfCliente;
        }
        public bool getAtraso(){
            return this.atraso;
        }
        public void setAtraso(bool atraso){
            this.atraso = atraso;
        }
        public float getTaxaAtraso(){
            return this.taxaAtraso;
        }
        public void setTaxaAtraso(float taxaAtraso){
            this.taxaAtraso = taxaAtraso;
        }

        public int getIdLivro(){
            return this.idLivro;
        }
        public void setIdLivro(int idLivro){
            this.idLivro = idLivro;
        }
        public bool getEmprestimoStatus(){
            return this.emprestimoStatus;
        }
        public void setEmprestimoStatus(bool emprestimoStatus){
            this.emprestimoStatus = emprestimoStatus;
        }

        public static void cadastroEmprestimo(string cpfResponsavel, string cpfCliente, int idLivro)
        {
            if (Emprestimo.possuiEmprestimoAtivo(cpfCliente))
            {
                Console.WriteLine("O Cliente já possui um CPF ativo.");
            }
            else
            {    
                DateTime hoje = DateTime.Today;
                Emprestimo emprestimo = new Emprestimo();
                emprestimo.setAtraso(false);
                emprestimo.setCpfCliente(cpfCliente);
                emprestimo.setCpfResponsavelEmprestimo(cpfResponsavel);
                emprestimo.setDataEmprestimo(hoje);
                emprestimo.setDataEntregaPrevista(hoje.AddDays(10));
                emprestimo.setIdLivro(idLivro);
                emprestimo.setEmprestimoStatus(true);
                Livro.pegarLivro(idLivro);

                FileStream emprestimoFile = new FileStream("C:\\projetos\\biblioteca\\arquivos\\emprestimos.txt", FileMode.Append, FileAccess.Write);
                StreamWriter swEmprestimo = new StreamWriter(emprestimoFile);
                string strEmprestimo = emprestimo.getDataEmprestimo().ToString("d") + ";" + emprestimo.getDataEntregaPrevista().ToString("d") + ";" + emprestimo.getDataEntrega().ToString("d") + ";" + emprestimo.getCpfCliente() + ";" + emprestimo.getCpfResponsavelEmprestimo() + ";" + emprestimo.getIdLivro() + ";" + emprestimo.getAtraso() + ";" + emprestimo.getTaxaAtraso() + ";" + emprestimo.getEmprestimoStatus();
                swEmprestimo.WriteLine(strEmprestimo);
                swEmprestimo.Close();
                emprestimoFile.Close();
                Console.WriteLine("Empréstimo realizado com sucesso!");
            }
        }

        public static bool devolverLivro(string cpfCliente)
        {
            if (!Emprestimo.possuiEmprestimoAtivo(cpfCliente))
            {
                return false;
            }
            Emprestimo emp = Emprestimo.retornaEmprestimo(cpfCliente);
            Emprestimo.atualizarEmprestimos(emp);
            return true;
        }

        private static void atualizarEmprestimos(Emprestimo emp)
        {
            string[] emprestimos = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\emprestimos.txt");
            string[] emprestimosAtualizado = new string[emprestimos.Length];
            for (int i = 0; i <= emprestimos.Length-1; i++)
            {
                string[] emprestimo = emprestimos[i].Split(";");
                if (emprestimo[3] == emp.getCpfCliente())
                {
                    emprestimosAtualizado[i] = emp.getDataEmprestimo().ToString("d") + ";" + emp.getDataEntregaPrevista().ToString("d") + ";" + emp.getDataEntrega().ToString("d") + ";" + emp.getCpfCliente() + ";" + emp.getCpfResponsavelEmprestimo() + ";" + emp.getIdLivro() + ";" + emp.getAtraso() + ";" + emp.getTaxaAtraso() + ";" + emp.getEmprestimoStatus();
                }
                else
                {
                    emprestimosAtualizado[i] = emprestimos[i];
                }
            }
            File.WriteAllText("C:\\projetos\\biblioteca\\arquivos\\emprestimos.txt", "");
            FileStream emprestimoArquivo = new FileStream("C:\\projetos\\biblioteca\\arquivos\\emprestimos.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swLivro = new StreamWriter(emprestimoArquivo);
            foreach (var e in emprestimosAtualizado)
            {    
                swLivro.WriteLine(e);
            }
            swLivro.Close();
            emprestimoArquivo.Close();
            Livro.devolverLivro(emp.getIdLivro());
        }
        private static bool possuiEmprestimoAtivo(string cpfCliente)
        {
            string[] todosEmprestimos = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\emprestimos.txt");
            foreach (var emprestimos in todosEmprestimos)
            {
                string[] emprestimo = emprestimos.Split(";");
                if (emprestimo[3] == cpfCliente && bool.Parse(emprestimo[8]))
                {
                    return true;
                }
            }
            return false;
        }
        private static Emprestimo retornaEmprestimo(string cpfCliente)
        {
            Emprestimo emp = new Emprestimo();
            string[] todosEmprestimos = File.ReadAllLines("C:\\projetos\\biblioteca\\arquivos\\emprestimos.txt");
            foreach (var emprestimos in todosEmprestimos)
            {
                string[] emprestimo = emprestimos.Split(";");
                if (emprestimo[3] == cpfCliente && bool.Parse(emprestimo[8]))
                {
                    emp.setDataEmprestimo(Convert.ToDateTime(emprestimo[0]));
                    emp.setDataEntregaPrevista(Convert.ToDateTime(emprestimo[1]));
                    emp.setDataEntrega(DateTime.Today);
                    emp.setCpfCliente(emprestimo[3]);
                    emp.setCpfResponsavelEmprestimo(emprestimo[4]);
                    emp.setIdLivro(Int32.Parse(emprestimo[5]));
                    emp.setAtraso(((emp.getDataEntrega() - emp.getDataEmprestimo()).Days > 0 ? true : false) );
                    if (emp.getAtraso())
                    {
                        emp.setTaxaAtraso( (emp.getDataEntrega() - emp.getDataEmprestimo()).Days * 10 );
                    }
                    else
                    {
                        emp.setTaxaAtraso(0);
                    }
                    emp.setEmprestimoStatus(false);
                    break;
                }
            }
            return emp;
        }

    }
}