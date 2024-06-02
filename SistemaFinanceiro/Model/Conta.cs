using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Conta
    {
        private long _numero;
        private decimal _saldo;
        private Cliente _titular;

        public Agencia agencia;
        public Cliente cliente;


        public Conta(long numero)
        {
            _numero = numero;
        }

        public Cliente Titular { get; private set; }

       

        public Conta(long numero, Cliente titular)
        {
            if (titular == null)
            {
                throw new ArgumentNullException("O titular da conta não pode ser nulo.");
            }

            _numero = numero;
            _saldo = 10;
            _titular = titular;
        }

        public Conta(long numero, decimal saldo, Cliente titular)
        {
            if (saldo < 10)
            {
                throw new ArgumentException("O saldo inicial não pode ser menor que R$10,00");
            }

            _saldo = saldo;
            _numero = numero;
        }

        public Conta(int numero)
        {
            this.Numero = numero;
        }

        public long Numero
        {
            get => _numero;
            private set
            {
                _numero = value;
            }
        }

        public decimal Saldo { get => _saldo; }

        // crie o código de teste para testar o método de depósito e saque da conta

        public virtual void Deposito(decimal valor)
        {
            if (valor > 0)
                _saldo += valor;
        }

        public virtual decimal Saque(decimal valor)
        {
            decimal imposto = valor + 0.10m;
            if (_saldo - imposto >= 0)
            {
                _saldo -= imposto;
                return _saldo;
            }
            else
            {
                throw new ArgumentException("Valor do saque ultrapassa o saldo");
            }
        }

    

        public void Transferencia(decimal valor, Conta contaDestino)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("A transferencia tem que ser maior que zero");
            }

            if (Saldo < valor)
            {
                throw new ArgumentException("Impossivel realizar a transferencia! O saldo ficará negativo");
            }
            if (Saldo > valor)
            _saldo -= valor;
            contaDestino._saldo += valor;
        }

        public class ContaCaixinha : Conta
        {
            public ContaCaixinha(long numero, decimal saldo, Cliente titular)
                : base(numero, saldo, titular)
            {
                if (saldo < 10)
                {
                    throw new ArgumentException("O saldo inicial deve ser superior a R$10,00");
                }
            }
            public override void Deposito(decimal valor)
            {
                if (valor < 1)
                {
                    throw new ArgumentException("Depósitos devem ser superiores a R$1,00");
                }

                base.Deposito(valor);
                _saldo += 1.00m;
            }

            
            public override decimal Saque(decimal valor)
            {
                decimal saqueValor = valor + 5.00m;
                if (Saldo >= saqueValor)
                {
                    _saldo -= 5.00m;
                    return base.Saque(valor);
                }
                else
                {
                    throw new ArgumentException("Valor do saque ultrapassa o saldo");
                }
            }
        }
    }
}

