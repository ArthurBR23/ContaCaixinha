using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Model
{
    public class Cliente
    {
        private string _nome, _cpf;
        private int _anoNascimento;


        public Cliente(string nome, string cpf, int anoNascimento)
        {
            _nome = nome;
            _cpf = cpf;
            _anoNascimento = anoNascimento;


            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome inválido");
            }
            else if (string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("CPF inválido");
            }
            else if (2024 - anoNascimento <= 18)
            {
                throw new ArgumentException("Cliente menor de idade, não é possivel realizar seu cadastro ");
            }
            else if (cpf.Length != 11)
            {
                throw new ArgumentException("CPF deve ter 11 digitos");
            }



        }

        public string Nome
        {
            get => _nome;
            private set
            {
                _nome = value;
            }
        }

        public string CPF
        {
            get => _cpf;
            private set
            {
                _cpf = value;
            }
        }

        public int AnoNascimento
        {
            get => _anoNascimento;
        }



    }
}