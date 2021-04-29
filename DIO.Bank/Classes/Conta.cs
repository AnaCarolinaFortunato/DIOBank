using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Bank
{
    public class Conta
    {
        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            TipoConta = tipoConta;
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
        }

        private TipoConta TipoConta { get;  set; }
        private string Nome { get;  set; }
        private double Saldo { get;  set; }
        private double Credito { get;  set; }
        
        //validacao de saldo
        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < (Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            Saldo = Saldo - valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
            return true;
        }

        public void Depositar (double valorDeposito)
        {
            Saldo = Saldo + valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);

        }

        public void Transferir(double valorTranferencia, Conta contaDestino)
        {
            if (Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
            Saldo = Saldo - valorTranferencia;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
           
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += " TipoConta " + TipoConta + " | ";
            retorno += " Nome " + Nome + " | ";
            retorno += " Saldo " + Saldo + " | ";
            retorno += " Crédito " + Credito + " | ";
            return retorno;
        }
    }
}
