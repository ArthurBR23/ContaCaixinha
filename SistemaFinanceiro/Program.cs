using System;
using SistemaFinanceiro.Model;
using static SistemaFinanceiro.Model.Conta;

public class Program
{
    public static void Main(string[] args)
    {
        
        //Cliente 1
        var cliente1 = new Cliente("Arthur", "12345678900", 2003);
        Console.WriteLine($"Nome: {cliente1.Nome}, CPF: {cliente1.CPF}, Ano de Nascimento: {cliente1.AnoNascimento}");

        var conta1 = new Conta(123456, 5000, cliente1);
        Console.WriteLine($"Cliente: {cliente1.Nome}, Conta: {conta1.Numero}, Saldo: R$:{conta1.Saldo}");

        //Cliente 2
        var cliente2 = new Cliente("Kananda", "12345678990", 2001);
        Console.WriteLine($"Nome: {cliente2.Nome}, CPF: {cliente2.CPF}, Ano de Nascimento: {cliente2.AnoNascimento}");

        var conta2 = new Conta(654321, 2341.42m, cliente2);
        Console.WriteLine($"Cliente: {cliente2.Nome}, Conta: {conta2.Numero}, Saldo: R$: {conta2.Saldo:C}");

        //Valor do saque
        decimal valorSaque = 500;
        conta1.Saque(valorSaque);
        Console.WriteLine($"Saldo da conta do {cliente1.Nome} após o saque é R$ {conta1.Saldo}");

        //Valor da transferência entre contas
        decimal valorTransferencia = 1000;
        conta1.Transferencia(valorTransferencia, conta2);
        Console.WriteLine($"Valor da Transferência da conta {conta1.Numero} é R${valorTransferencia} para a conta {conta2.Numero}");

        //Saldo das contas após a transferência
        Console.WriteLine($"Saldo do(a): {cliente1.Nome} da conta: {conta1.Numero} após a transferência é: R$ {conta1.Saldo}");
        Console.WriteLine($"Saldo do(a): {cliente2.Nome} da conta: {conta2.Numero} após a transferência é: R$ {conta2.Saldo}");

        if (conta1.Saldo > conta2.Saldo)
        {
            Console.WriteLine($"A conta com maior saldo é: R$ {conta1.Saldo}, que pertence ao cliente {cliente1.Nome}");
        }
        else
        {
            Console.WriteLine($"A conta com maior saldo é: R$ {conta2.Saldo}, que pertence ao cliente {cliente2.Nome}");
        }
        
       
        //Cliente 3
        var cliente3 = new Cliente("Rosenclever","12345678902", 2001);
        Console.WriteLine($"Nome: {cliente3.Nome}, CPF: {cliente3.CPF}, Ano de Nascimento: {cliente3.AnoNascimento}");

        var contaCaixinha = new ContaCaixinha(123, 2500, cliente3);
        Console.WriteLine($"Cliente: {cliente3.Nome}, Conta: {contaCaixinha.Numero}, Saldo: R$:{contaCaixinha.Saldo}");
        
        contaCaixinha.Deposito(300);
        Console.WriteLine($"Saldo após depósito: R$ {contaCaixinha.Saldo}");
        contaCaixinha.Saque(700);
        Console.WriteLine($"Saldo após saque: R$ {contaCaixinha.Saldo}");
    }
}
