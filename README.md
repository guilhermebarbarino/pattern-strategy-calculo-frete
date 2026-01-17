# 🎯 pattern-strategy-calculo-frete

Este projeto é uma **aplicação Console em .NET** criada com o objetivo de demonstrar, de forma prática, a aplicação do **Design Pattern Strategy** em um cenário real de **cálculo de frete**.

O foco principal está em **boas práticas de arquitetura**, **Clean Code**, **SOLID** e **testes unitários focados em comportamento**, servindo como material de estudo e portfólio.

---

## 🧠 Sobre o Strategy Pattern

O **Strategy Pattern** é um padrão comportamental que permite definir uma família de algoritmos, encapsular cada um deles em classes separadas e torná‑los intercambiáveis em tempo de execução.

Neste projeto, cada forma de cálculo de frete é representada por uma **estratégia independente**, eliminando estruturas condicionais complexas (`if/else` ou `switch`) e tornando o código mais extensível e testável.

---

## 🎯 Objetivo do Projeto

- Aplicar o Strategy Pattern em um cenário realista
- Evitar condicionais de negócio espalhadas pelo código
- Demonstrar o princípio **Open/Closed**
- Criar uma base extensível para novos tipos de frete
- Escrever testes unitários claros e confiáveis

Este projeto faz parte de uma iniciativa de estudo contínuo:
**1 Design Pattern por dia, com implementação prática em .NET**

---

## 🧩 Cenário Implementado

O sistema calcula o valor do frete com base em:

- CEP de origem
- CEP de destino
- Peso da encomenda (kg)
- Distância (km)
- Tipo de frete

### Tipos de Frete (Strategies)

- **Frete Econômico**
- **Frete Expresso**
- **Retirada na Loja**

Cada tipo de frete possui sua própria lógica encapsulada em uma classe que implementa a interface de estratégia.

---

## 🏗️ Estrutura da Solução

```text
pattern-strategy-calculo-frete
│
├── CalculoFrete.Dominio
│   ├── Contratos
│   ├── Modelos
│   └── Tipos
│
├── CalculoFrete.Aplicacao
│   └── Servicos
│
├── CalculoFrete.Infra
│   └── Estrategias
│
├── CalculoFrete.ConsoleApp
│   └── UI
│
├── CalculoFrete.Testes
│   ├── Dublês
│   └── Testes de Comportamento
│
└── pattern-strategy-calculo-frete.sln
```

---

## 🧠 Responsabilidade das Camadas

### Domínio
Contém as regras de negócio, contratos e modelos.  
Não depende de nenhuma tecnologia externa.

### Aplicação
Responsável por orquestrar o fluxo e selecionar a estratégia correta de cálculo.

### Infra
Implementações concretas das estratégias de frete.

### ConsoleApp
Interface de linha de comando.  
Responsável apenas pela interação com o usuário.

### Testes
Testes unitários focados em **comportamento**, utilizando dublês (fakes) para isolar o domínio.

---

## 🔍 Onde o Strategy é aplicado

O contrato central do padrão é:

```csharp
IEstrategiaCalculoFrete
```

Cada tipo de frete implementa essa interface.

O serviço `ServicoCalculoFrete` recebe todas as estratégias registradas e seleciona **a primeira que atende** à solicitação, sem conhecer detalhes da implementação concreta.

---

## 🧪 Testes Unitários

Os testes cobrem:

- Seleção correta da estratégia
- Ordem de precedência entre estratégias
- Garantia de que apenas uma estratégia é executada
- Falha controlada quando nenhuma estratégia atende
- Validação de regras de entrada

Todos os testes são focados em **comportamento**, não em detalhes de implementação.

---

## ▶️ Como Executar o Projeto

### Pré-requisitos

- .NET SDK 7.0 ou superior

### Executar a aplicação

```bash
dotnet run --project CalculoFrete.ConsoleApp
```

### Executar os testes

```bash
dotnet test
```

---

## 🚀 Extensão do Sistema

Para adicionar um novo tipo de frete:

1. Criar uma nova classe que implemente `IEstrategiaCalculoFrete`
2. Registrar a nova estratégia no container de DI
3. Nenhuma alteração no código existente é necessária

Isso garante aderência total ao princípio **Open/Closed**.

---

## 📌 Conceitos Aplicados

- Strategy Pattern
- SOLID (SRP, OCP, DIP)
- Clean Code
- Inversão de Dependência
- Testes unitários com foco em comportamento
- Arquitetura em camadas

---

## 📚 Referência

- https://refactoring.guru/design-patterns/strategy

---

## ✍️ Autor

Projeto desenvolvido por **Guilherme Barbarino** como estudo prático de **Design Patterns em .NET**, com foco em arquitetura, qualidade de código e boas práticas.
