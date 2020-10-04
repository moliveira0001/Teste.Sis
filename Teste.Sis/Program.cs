using System;
using System.Collections.Generic;

namespace Teste.Sis
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                
                double   _ValorCredito = 0;
                DateTime _dataVencto;
                int      _qtdeParcelas=0;

            Inicio:
                Console.Clear();
                Console.WriteLine("Digite o valor do crédito");
                 

                if (!double.TryParse(Console.ReadLine(), out _ValorCredito))
                {
                    Console.WriteLine("O valor deve ser númerico");
                   
                    goto Inicio;
                }              

                MenuOperacoes();

                DigitarOpcao:

                int opcao = 0;


                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("O valor deve ser númerico");
                   
                    goto DigitarOpcao;
                }

                if (!opcao.IsBetween(1,5))
                {
                    Console.WriteLine("Opção Inválida");
                   
                    goto DigitarOpcao;
                }


                Credito credito = CreditoFactory.EscolherCredito(opcao);

                credito.ValorCredito = _ValorCredito;

                Console.WriteLine("Digite o vencimento");


                DataVencimento:

                if (DateTime.TryParse(Console.ReadLine(), out _dataVencto))
                {
                    credito.DataVencimento = _dataVencto;
                }
                else
                {
                    Console.WriteLine("Digite uma data válida");
                    goto DataVencimento;
                }

                
                Parcelas:
                Console.WriteLine("Digite a quantidade de parcelas");

                if (int.TryParse(Console.ReadLine(), out _qtdeParcelas))
                {
                    credito.QtdeParcelas = _qtdeParcelas;
                }
                else
                {
                    Console.WriteLine("Quantidade de parcelas deve ser numerico!");
                    goto Parcelas;
                }               

                credito.LiberaCredito();

                Console.WriteLine("O status do crédito é: " + credito.StatusCredito);

                Console.WriteLine(credito.Mensagem);

                if (string.IsNullOrEmpty(credito.Mensagem))
                {
                    Console.WriteLine("O valor do financiamento é: " + credito.CalculaTaxa(_ValorCredito));

                    Console.WriteLine("O valor do juros é: " + (credito.CalculaTaxa(_ValorCredito) - _ValorCredito));
                }

                Console.ReadKey();
                goto Inicio;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                Console.ReadKey();
            }

        }


        private static void MenuOperacoes()
        {

            Console.WriteLine("Escolha uma opção de Crédito!");
            Console.WriteLine();
            Console.WriteLine("Escolha sua opção:");
            Console.WriteLine();
            Console.WriteLine("1 - Crédito direto");
            Console.WriteLine("2 - Crédito consignado");
            Console.WriteLine("3 - Crédito Pessoa física");
            Console.WriteLine("4 - Crédito Pessoa juridica");
            Console.WriteLine("5 - Crédito Imobiliário");
        }

       
    }
}
