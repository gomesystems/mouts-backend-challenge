# MOUTSTI

## Caso de Uso

**Você é um desenvolvedor na equipe DeveloperStore. Agora precisamos implementar os protótipos da API.**

Como trabalhamos com `DDD`, para referenciar entidades de outros domínios utilizamos o padrão `Identidades Externas` com desnormalização das descrições das entidades.

Portanto, você deverá escrever uma API (CRUD completo) que manipule registros de vendas. A API precisa ser capaz de informar:

* Número da venda
* Data em que a venda foi realizada
* Cliente
* Valor total da venda
* Filial onde a venda foi realizada
* Produtos
* Quantidades
* Preços unitários
* Descontos
* Valor total de cada item
* Cancelada / Não cancelada

Não é obrigatório, mas será um diferencial construir código para publicar eventos de:

* SaleCreated (VendaCriada)
* SaleModified (VendaAlterada)
* SaleCancelled (VendaCancelada)
* ItemCancelled (ItemCancelado)

Se você escrever o código, **não é necessário** realmente publicar em nenhum Message Broker. Você pode apenas registrar uma mensagem no log da aplicação ou da forma que considerar mais conveniente.

### Regras de Negócio

* Compras acima de 4 itens idênticos têm 10% de desconto
* Compras entre 10 e 20 itens idênticos têm 20% de desconto
* Não é possível vender mais de 20 itens idênticos
* Compras abaixo de 4 itens não podem ter desconto

Essas regras de negócio definem faixas de desconto baseadas na quantidade e suas limitações:

1. Faixas de Desconto:

   * 4+ itens: 10% de desconto
   * 10 a 20 itens: 20% de desconto

2. Restrições:

   * Limite máximo: 20 itens por produto
   * Nenhum desconto permitido para quantidades abaixo de 4 itens

## Visão Geral

Esta seção fornece uma visão de alto nível do projeto e das diversas habilidades e competências que ele busca avaliar em candidatos a desenvolvedor.

Veja [Visão Geral](/.doc/overview.md)

## Stack Tecnológica

Esta seção lista as principais tecnologias usadas no projeto, incluindo backend, testes, frontend e banco de dados.

Veja [Stack Tecnológica](/.doc/tech-stack.md)

## Frameworks

Esta seção descreve os frameworks e bibliotecas utilizados no projeto para aumentar a produtividade e a manutenibilidade do desenvolvimento.

Veja [Frameworks](/.doc/frameworks.md)

<!-- 
## Estrutura da API
Esta seção inclui links para a documentação detalhada dos diferentes recursos da API:
- [API Geral](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Estrutura do Projeto

Esta seção descreve a estrutura geral e a organização dos arquivos e diretórios do projeto.

Veja [Estrutura do Projeto](/.doc/project-structure.md)

---

👉 Quer que eu monte um **resumo em português** pronto para apresentar em entrevista, em vez da tradução literal do desafio?
