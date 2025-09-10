# TRANSACTIONS API 

Projeto para testar os fundamentos da criação de uma API em ASP.NET 8.

# 📜 Regras de Negócio

Este documento descreve as regras e validações essenciais que governam o funcionamento do sistema de controle financeiro.

---

### 👤 **Gerenciamento de Pessoas**

* ✅ **ID Automático:** Cada pessoa recebe um `id` numérico, único e sequencial, gerado automaticamente.
* ✅ **Dados Essenciais:** Os campos para cadastro são `name` (texto) e `age` (número inteiro).
* ✅ **Operações:** O sistema suporta as operações de **Listar**, **Criar** e **Deletar** pessoas.
* 🚨 **Exclusão em Cascata:** Ao **deletar** uma pessoa, todas as suas transações associadas são **automaticamente removidas** do banco de dados.

---

### 💸 **Gerenciamento de Transações**

* ✅ **ID Automático:** Cada transação recebe um `id` numérico, único e sequencial.
* ✅ **Vínculo Obrigatório:** Uma transação deve estar **obrigatoriamente** associada a uma pessoa existente.
* ✅ **Dados da Transação:** Os campos são `description` (texto), `amount` (decimal > 0), `type` (`income` ou `expense`) e o idSubject.
* ✅ **Operações:** Apenas **Criação** e **Listagem** de transações são necessárias.
* ⚠️ **Restrição de Idade:** Pessoas com **menos de 18 anos** (`age` < 18) **NÃO PODEM** ter transações do tipo `income`. O sistema deve bloquear esta operação.

---

### 📊 **Consultas e Relatórios**

O sistema deve gerar um relatório financeiro consolidado com as seguintes características:

* 🧾 **Listagem Individual:** Exibe uma lista de **todas as pessoas** cadastradas, mostrando para cada uma:
    * O total de `income` (entradas).
    * O total de `expense` (saídas).
    * O saldo final (`receitas` - `despesas`).
* 💹 **Total Geral:** Ao final do relatório, apresenta um **resumo global** com a soma de todas as receitas, todas as despesas e o saldo líquido total do sistema.
