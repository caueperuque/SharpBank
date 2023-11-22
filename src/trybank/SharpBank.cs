using System.Linq.Expressions;

namespace SharpBank.Lib;

public class SharpBankLib
{
    public bool Logged;
    public int loggedUser;

    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;

    public SharpBankLib()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    // Funcionalidade de cadastrar novas contas
    public void RegisterAccount(int number, int agency, int pass)
    {
        if (registeredAccounts >= maxAccounts)
        {
            throw new Exception("Limite de contas atingido!");
        }

        for (int i = 0; i < registeredAccounts; i++)
        {
            if (Bank[i, 0] == number && Bank[i, 1] == agency)
            {
                throw new ArgumentException("A conta já está sendo usada!");
            }
        }

        Bank[registeredAccounts, 0] = number;
        Bank[registeredAccounts, 1] = agency;
        Bank[registeredAccounts, 2] = pass;
        Bank[registeredAccounts, 3] = 0;

        registeredAccounts++;
    }


    // Funcionalidade de fazer Login
    public void Login(int number, int agency, int pass)
    {
        if (Logged)
        {
            throw new AccessViolationException("Usuário já está logado");
        }

        for (int i = 0; i < registeredAccounts; i++)
        {
            if (Bank[i, 0] == number && Bank[i, 1] == agency && Bank[i, 2] == pass)
            {
                Logged = !Logged;
                loggedUser = Bank[registeredAccounts, i];
            }
            else if (Bank[i, 0] == number && Bank[i, 1] == agency && Bank[i, 2] != pass)
            {
                throw new ArgumentException("Senha incorreta");
            }
            else
            {
                throw new ArgumentException("Agência + Conta não encontrada");
            }
        }
    }

    // Funcionalidade de fazer Logout
    public void Logout()
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        Logged = !Logged;
        loggedUser = -99;
    }

    // Funcionalidade de checar o saldo
    public int CheckBalance()
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        return Bank[loggedUser, 3];
    }

    // Funcionalidade de depositar dinheiro
    public void Deposit(int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        Bank[loggedUser, 3] = value;
    }

    // Funcionalidade de sacar dinheiro
    public void Withdraw(int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        if (Bank[loggedUser, 3] < value)
        {
            throw new InvalidOperationException("Saldo insuficiente");
        }
        Bank[loggedUser, 3] -= value;
    }

    // Funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        for (int i = 0; i < registeredAccounts; i++)
        {
            if (Bank[loggedUser, 3] < value)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }
            if (Bank[i, 0] == destinationNumber && Bank[i, 1] == destinationAgency)
            {
                Bank[loggedUser, 3] -= value;
                Bank[i, 3] += value;
            }
        }
    }


}
