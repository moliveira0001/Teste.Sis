using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Sis
{
    public static class CreditoFactory
    {

        public static Credito EscolherCredito(int tipoCredito)
        {
            switch (tipoCredito)
            {
                case (int)TipoCredito.Direto: return new CreditoDireto();
                case (int)TipoCredito.Consignado: return new CreditoConsignado();
                case (int)TipoCredito.Imobiliario: return new CreditoImobiliario();
                case (int)TipoCredito.PessoaFisica: return new CreditoPessoaFisica();
                case (int)TipoCredito.PessoaJuridica: return new CreditoPessoaJuridica();
                default: return null;
            }

        }

    }
}


