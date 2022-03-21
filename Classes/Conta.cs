using System;

namespace ProjetoBank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set; }
        private double Saldo {get; set; }
        private double Credito {get; set; }
        private string Nome {get; set; }
        private int NumeroConta {get;set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, int numeroconta)
        {
        this.TipoConta = tipoConta;
        this.Saldo = saldo;
        this.Credito = credito;
        this.Nome = nome;
        this.NumeroConta = numeroconta;
        }
        
        public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta {0} de {1} é {2}", this.NumeroConta, this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta {0} de {1} é {2}", this.NumeroConta, this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "NúmeroConta " + this.NumeroConta + " | ";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}

    }
}