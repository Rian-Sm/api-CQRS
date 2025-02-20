# API CQRS de Clientes

## Estrutura do Projeto

Projeto segue padrão CQRS de API

```plaintext
src/ # Raiz dos projetos
├── POC.Domain/  # Contém a lógica de negócios e modelos dos dados
├── POC.Infra.CrossCutting.Bus/  # Contém a classlib de event bus em memória
├── POC.Infra.CrossCutting.Cache/  # Contém a classlib de implementação de cache em memória
├── POC.Infra.CrossCutting.IoC/  # Contém a implementação de inversão de dependência (IoC) 
├── POC.Infra.Data/  # Contém a implementacão dos dados (docker / migração / bdcontext / repository)
├── POC.SERVICE.API/  # Contém a implemetação da API 
```

### Frameworks and Libraries

- AutoMapper
- FluentValidation
- MediatR
- Microsoft.EntityFrameworkCore
- Npgsql.EntityFrameworkCore.PostgreSQL
- Swagger UI
- System.Runtime.Caching

## Run CLI

Para rodar os testes siga os comando abaixo a baixo na pasta raiz do projeto:

```bash
cd src/POC.SERVICE.API/

dotnet run 
```

## Run Testes

Posteriormente será desenvolvido os devidos testes

## Proximas etapas:

As proximas atividades que estão sendo desenvolvidas sendo atualizadas nas issues do projeto
