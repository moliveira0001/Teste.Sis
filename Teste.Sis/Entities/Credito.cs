using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Sis
{
    public abstract class Credito : ICredito
    {


        private int _parcelasMinimas = 5;

        private int _parcelasMaximas = 72;

        public double _valorMaximo = 10000000.00;

        public DateTime DataVencimento { get; set; }
        public string StatusCredito { get; set; } = "APROVADO";
        public string Mensagem { get; set; }
        public int QtdeParcelas { get; set; }
        public double ValorCredito { get; set; }
        public abstract double CalculaTaxa(double valor);

        private void ValidaVencimento()
        {
            if (this.DataVencimento < System.DateTime.Now.AddDays(15))
            {
                StatusCredito = "Recusado ";
                Mensagem += "\nData de vencimento deve ser superior a: " + System.DateTime.Now.AddDays(15).ToShortDateString();
            }
            else
            if (this.DataVencimento > System.DateTime.Now.AddDays(40))
            {
                StatusCredito = "Recusado ";
                Mensagem += "\nData de vencimento deve ser inferior a: " + System.DateTime.Now.AddDays(40).ToShortDateString();
            }
        }

        private void ValidaParcelas()
        {
            if (QtdeParcelas < _parcelasMinimas || QtdeParcelas > _parcelasMaximas)
            {
                StatusCredito = "Recusado";
                Mensagem += "\no número de parcelas deve estar entre 5 e 72";
            }
        }

        private void ValidaValorMaximo()
        {
            if (ValorCredito > _valorMaximo)
            {
                StatusCredito = "Recusado";
                Mensagem += "\nValor Maximo excedido";
            }

        }

        public virtual void LiberaCredito()
        {
            ValidaValorMaximo();
            ValidaVencimento();
            ValidaParcelas();
        }
    }
}
