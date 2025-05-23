Aqui está o projeto completo chamado **PetCareManager**, uma aplicação para cadastro e gerenciamento de animais de estimação e seus donos. A seguir, detalho os principais pontos, arquitetura, funcionamento, estrutura de diretórios, código e como rodar o projeto.

---

## 💡 Ideia do App

**PetCareManager** é um app para clínicas veterinárias ou tutores acompanharem animais e seus dados principais (nome, espécie, idade) e os dados dos donos (nome, telefone, e-mail). Ele permite:

* Cadastro de donos
* Cadastro de animais vinculados aos donos
* Listagem, edição e exclusão
* API com Swagger para testes
* App MAUI com pelo menos duas telas

---

## 🧱 Estrutura de Diretórios

```
PetCareManager/
├── PetCareManager.API/              # Projeto WebAPI (.NET 7+)
│   ├── Controllers/
│   │   ├── PetsController.cs
│   │   └── OwnersController.cs
│   ├── Models/
│   │   ├── Pet.cs
│   │   └── Owner.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Program.cs
│   ├── appsettings.json
├── PetCareManager.MAUI/            # Projeto MAUI App
│   ├── Views/
│   │   ├── OwnerListPage.xaml
│   │   ├── PetListPage.xaml
│   ├── ViewModels/
│   │   ├── OwnerViewModel.cs
│   │   ├── PetViewModel.cs
│   ├── Models/
│   │   ├── Owner.cs
│   │   ├── Pet.cs
│   ├── Services/
│   │   ├── ApiService.cs
│   ├── App.xaml.cs
│   └── MainPage.xaml
```

---

## 🏛️ Arquitetura

### Backend (ASP.NET WebAPI)

* **Entity Framework Core** para persistência com SQLite
* Relacionamento: `Owner (1) -> (n) Pet`
* Endpoints REST para `/api/owners` e `/api/pets`
* Documentação Swagger para testes

### Frontend (MAUI App)

* MVVM com `ViewModels` e `Views`
* Consumo de API via `HttpClient`
* Duas telas principais:

  * Lista de donos
  * Lista de pets de um dono

---

## 🔁 Comunicação entre App e API

1. O app MAUI chama a WebAPI usando `HttpClient`.
2. As chamadas são feitas para endpoints REST (GET/POST/PUT/DELETE).
3. A API responde com JSON que é desserializado no app.
4. O app exibe ou envia os dados via ViewModels.

---

## 🧪 Swagger

* A API gera documentação interativa automaticamente.
* Acesse via `https://localhost:PORT/swagger` (ao rodar localmente).

---

## 📦 README.md

````markdown
# PetCareManager

Um sistema completo com .NET MAUI e WebAPI + Entity Framework para gerenciar donos e pets.

## 🛠 Tecnologias

- .NET MAUI
- ASP.NET Core WebAPI
- Entity Framework Core
- SQLite
- Swagger

## 📦 Como Rodar

### Backend

```bash
cd PetCareManager.API
dotnet restore
dotnet ef database update
dotnet run
````

Acesse Swagger em `https://localhost:{porta}/swagger`

### Frontend

```bash
cd PetCareManager.MAUI
dotnet restore
dotnet build
dotnet run
```

* Altere a URL base no `ApiService.cs` se necessário.

## Funcionalidades

* Cadastro de Donos e Pets
* Relacionamento 1\:N
* Listagem, Edição, Exclusão
* Integração MAUI ↔ WebAPI
* Swagger com testes

## Estrutura de Diretórios

📁 PetCareManager
├── PetCareManager.API
├── PetCareManager.MAUI

## Autores

Desenvolvido para fins educacionais.

