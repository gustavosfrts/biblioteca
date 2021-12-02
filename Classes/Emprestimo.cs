using System;

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

    }
}