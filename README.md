# Projeto SharpBank - Banco Virtual :blue_heart:

O SharpBank é um projeto inicial de um banco virtual que visa controlar contas bancárias e realizar operações básicas como saldo, depósito, saque, transferência e gestão de contas.

## Objetivo

O objetivo deste projeto é criar uma aplicação que simula operações bancárias, permitindo cadastro, login e operações financeiras básicas.

## Funcionalidades Principais

- **Cadastro de Contas:** Cadastre novas contas com número, agência, senha e saldo.
- **Login e Logout:** Acesso seguro às contas bancárias.
- **Operações Financeiras:** Realize checagem de saldo, deposite, saque e transfira dinheiro entre contas.

## Armazenamento de Dados

Os dados das contas são armazenados em um array multidimensional em memória. Ao reiniciar o programa, os dados são reiniciados.

## Exemplo de Estrutura de Dados

Cada conta é representada por um array com número, agência, senha e saldo.

```python
# Exemplo de estrutura de dados das contas no array
conta = [
    [numero_da_conta_1, agencia_1, senha_1, saldo_1],
    [numero_da_conta_2, agencia_2, senha_2, saldo_2],
    # ... e assim por diante
]

Este projeto é uma simulação inicial de um sistema bancário e não persiste os dados entre reinicializações.