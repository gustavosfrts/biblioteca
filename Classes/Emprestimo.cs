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
    }
}