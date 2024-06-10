# DesafioAPI - Agenda de Tarefas

Este projeto é uma aplicação ASP.NET Core MVC para gerenciar tarefas. Ele permite criar, editar, deletar e buscar tarefas por título, data e status.

## Requisitos

- .NET 6.0 SDK ou superior
- SQL Server

## Configuração do Ambiente

1. **Clone o Repositório**

   ```bash
   git clone https://github.com/seu-usuario/DesafioAPI.git
   cd DesafioAPI

2. **Configuração do Banco de Dados**

Atualize a string de conexão no arquivo appsettings.Development.json para corresponder ao seu ambiente:
```bash
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=localhost\\sqlexpress;Initial Catalog=TarefaMvc;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

3. **Migrations e Atualização do Banco de Dados**

Adicione as migrations e atualize o banco de dados:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

# Estrutura do Projeto
## Context

**OrganizadorContext:** Classe de contexto do Entity Framework Core para acessar o banco de dados.

## Models

**Tarefa:** Classe que representa uma tarefa.
**EnumStatusTarefa:** Enumeração que define os estados de uma tarefa (Pendente, Finalizado).

**Controllers:**

**TarefaController:** Controlador que gerencia as operações CRUD das tarefas.

## Views


**Index:** Lista todas as tarefas.

**Criar:** Formulário para criar uma nova tarefa.

**Editar:** Formulário para editar uma tarefa existente.

**Deletar:** Confirmação de exclusão de uma tarefa.

**BuscarPorTitulo:** Formulário para buscar tarefas pelo título.

**BuscarPorData:** Formulário para buscar tarefas pela data.

**BuscarPorStatus:** Formulário para buscar tarefas pelo status.

# Funcionalidades
**Listar Tarefas:** Visualize todas as tarefas na página inicial.

**Criar Tarefa:** Adicione novas tarefas com título, descrição, data e status.

**Editar Tarefa:** Atualize as informações de uma tarefa existente.

**Deletar Tarefa:** Remova uma tarefa do sistema.

**Buscar Tarefas por Título:** Encontre tarefas que correspondem ao título fornecido.

**Buscar Tarefas por Data:** Encontre tarefas que correspondem à data fornecida.

**Buscar Tarefas por Status:** Encontre tarefas que correspondem ao status fornecido.

## Contribuição
Se você quiser contribuir com este projeto, por favor, siga os passos abaixo:

Fork este repositório.
Crie um branch para sua feature (git checkout -b feature/nome-da-feature).

Commit suas mudanças (git commit -am 'Adiciona nova feature').

Push para o branch (git push origin feature/nome-da-feature).

Abra um Pull Request.
