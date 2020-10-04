using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Sis
{
    public class CreditoDireto : Credito
    {
        public override double CalculaTaxa(double valor)
        {
            return valor + (valor * 0.02);
        }
    }
}
