# E Shop Management System

This is a EShop Management System built using ASP.NET Core and Entity Framework Core. It provides APIs to manage products and categories, including CRUD operations.

---

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [License](#license)

---

## Features

- Create, Read, Update, and Delete (CRUD) operations for **Products**.
- Manage **Categories** associated with products.
- Database integration using Entity Framework Core.
- Automatic seeding of products and categories from JSON files.

---

## Technologies Used

- **Framework**: ASP.NET Core
- **Database**: Microsoft SQL Server (or other configured providers)
- **ORM**: Entity Framework Core
- **Dependency Injection**: Built-in ASP.NET Core DI
- **Serialization**: Newtonsoft.Json

---

## Prerequisites

Ensure you have the following installed on your system:

1. [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later)
2. [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or other compatible database provider)
3. [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

---

## Setup Instructions

### 1. Clone the Repository
Clone this repository to your local machine:
```bash
git clone https://github.com/huynhdaihuy/EShop.git
cd eShopManagement

----
#### 2.Apply database migrations:

dotnet ef database update

##### 3.Build and run the Application

dotnet build
dotnet run
