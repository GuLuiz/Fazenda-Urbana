# Documentação do Proof of Concept (PoC)

## 1. Introdução
Este documento descreve o Proof of Concept (PoC) desenvolvido para demonstrar a implementação básica de um sistema de gerenciamento de fazenda urbana. O PoC inclui funcionalidades para gerenciar fornecedores, matéria-prima, produção e visualização de detalhes de pedidos.

## 2. Requisitos
- Microsoft .NET Framework 4.7.2 ou superior
- Acesso a um banco de dados Microsoft SQL Server

## 3. Instalação
1. Clone ou faça o download do repositório.
2. Abra o projeto em seu ambiente de desenvolvimento preferido.
3. Configure a conexão com o banco de dados no arquivo de configuração, se aplicável.
4. Compile e execute o projeto.

## 4. Utilização
- Ao iniciar o aplicativo, você será apresentado a um menu principal com opções para acessar diferentes funcionalidades.
- Escolha uma das opções para interagir com o sistema:
  - **Fornecedores**: Inserir, listar, atualizar ou deletar fornecedores.
  - **Matéria-Prima**: Inserir, listar, atualizar ou deletar matéria-prima.
  - **Produção**: Inserir, listar, atualizar ou deletar produções.
  - **Detalhes de um Pedido**: Visualizar detalhes de um pedido específico.
  - **Sair**: Encerra o programa.
- Siga as instruções apresentadas no console para cada opção selecionada.

## 5. Limitações
- Este PoC é uma implementação básica e pode não incluir todas as funcionalidades de um sistema de gerenciamento completo.
- Não há suporte para autenticação de usuário ou controle de acesso.
- A interface do console pode ser limitada em termos de usabilidade e experiência do usuário.

## 6. Exemplos
```csharp
// Exemplo de inserção de fornecedor
FornecedorRepositorio fornecedorRepo = new FornecedorRepositorio();
fornecedorRepo.InserirFornecedor();

// Exemplo de listagem de matéria-prima
MateriaPrimaRepositorio materiaPrimaRepo = new MateriaPrimaRepositorio();
materiaPrimaRepo.ListarMateriasPrimas();
