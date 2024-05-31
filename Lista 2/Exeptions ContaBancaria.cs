using System;
using System.Collections.Generic;
// Classe ValorInvalidoException
class ValorInvalidoException extends Exception {
    private double valorInvalido;

    public ValorInvalidoException(String mensagem, double valorInvalido) {
        super(mensagem);
        this.valorInvalido = valorInvalido;
    }

    public double getValorInvalido() {
        return valorInvalido;
    }
}

// Classe SaldoInsuficienteException
class SaldoInsuficienteException extends Exception {
    private double saldoDisponivel;

    public SaldoInsuficienteException(String mensagem, double saldoDisponivel) {
        super(mensagem);
        this.saldoDisponivel = saldoDisponivel;
    }

    public double getSaldoDisponivel() {
        return saldoDisponivel;
    }
}

// Classe ContaBancaria
class ContaBancaria {
    private double saldo;

    public ContaBancaria(double saldoInicial) {
        this.saldo = saldoInicial;
    }

    public void sacar(double valor) throws SaldoInsuficienteException, ValorInvalidoException {
        if (valor <= 0) {
            throw new ValorInvalidoException("Valor inválido para saque: " + valor, valor);
        }
        if (valor > saldo) {
            throw new SaldoInsuficienteException("Saldo insuficiente para saque: " + saldo, saldo);
        }
        saldo -= valor;
    }

    public void depositar(double valor) throws ValorInvalidoException {
        if (valor <= 0) {
            throw new ValorInvalidoException("Valor inválido para depósito: " + valor, valor);
        }
        saldo += valor;
    }

    public void transferir(double valor, ContaBancaria outraConta) throws SaldoInsuficienteException, ValorInvalidoException {
        this.sacar(valor);
        outraConta.depositar(valor);
    }

    public double getSaldo() {
        return saldo;
    }
}

// Classe principal
public class Main {
    public static void main(String[] args) {
        ContaBancaria conta1 = new ContaBancaria(1000);
        ContaBancaria conta2 = new ContaBancaria(500);

        try {
            conta1.depositar(200);
            conta2.sacar(100);
            conta1.transferir(300, conta2);
            conta2.sacar(800); // Isso deve lançar uma SaldoInsuficienteException
        } catch (ValorInvalidoException e) {
            System.out.println("Erro: " + e.getMessage() + ", Valor inválido: " + e.getValorInvalido());
        } catch (SaldoInsuficienteException e) {
            System.out.println("Erro: " + e.getMessage() + ", Saldo disponível: " + e.getSaldoDisponivel());
        }
    }
}
