using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Sis
{
    public class CreditoImobiliario : Credito
    {
        public override double CalculaTaxa(double valor)
        {
            return valor +(valor * 0.09);
        }
    }
}
