using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Sis
{
    public class CreditoPessoaJuridica : Credito
    {

        private double _valorMinimo = 15000.00;

        public override double CalculaTaxa(double valor)
        {
            return valor + (valor * 0.05);
        }

        public override void LiberaCredito()
        {

            if (ValorCredito < _valorMinimo)
            {
                StatusCredito = "RECUSADO";
                Mensagem += "\n O valor mínimo do crédito para pessoa jurídica deve ser: " + _valorMinimo;
            }
            
            base.LiberaCredito();
        }
    }
}
