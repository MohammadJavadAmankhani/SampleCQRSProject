# 🏗️ SampleCQRSProject 🚀

> **A clean architecture implementation of CQRS with MediatR, Entity Framework Core, and xUnit in .NET 8.**  
> A full-featured backend project following best practices in software design.

---

## 📌 Features
✅ **CQRS (Command Query Responsibility Segregation)** using `MediatR`  
✅ **Event Sourcing** with `IEventStore`  
✅ **Repository Pattern & Unit of Work**  
✅ **Entity Framework Core (EF Core) with SQLite**  
✅ **FluentValidation for Model Validation**  
✅ **Unit Testing with `xUnit`, `Moq`, and `InMemoryDatabase`**  
✅ **API Documentation with Swagger (`Swashbuckle`)**  

---

## 🚀 How to Run
1️⃣ **Clone the repository:**
   ```sh
   git clone https://github.com/MohammadJavadAmankhani/SampleCQRSProject.git
   cd SampleCQRSProject

2️⃣ Install dependencies:
dotnet restore
3️⃣ Build the project:
dotnet build
4️⃣ Run the project:
dotnet run
5️⃣ Open Swagger UI:
Visit: http://localhost:5000/swagger


📂 Project Structure

📂 SampleCQRSProject
 ┣ 📂 API
 ┃ ┣ 📜 Program.cs
 ┃ ┣ 📜 appsettings.json
 ┃ ┣ 📂 Controllers
 ┃ ┃ ┣ 📜 ProductController.cs
 ┣ 📂 Application
 ┃ ┣ 📂 Commands
 ┃ ┃ ┣ 📜 CreateProductCommand.cs
 ┃ ┣ 📂 Queries
 ┃ ┃ ┣ 📜 GetAllProductsQuery.cs
 ┃ ┣ 📂 Handlers
 ┃ ┃ ┣ 📜 CreateProductHandler.cs
 ┃ ┃ ┣ 📜 GetAllProductsHandler.cs
 ┣ 📂 Domain
 ┃ ┣ 📂 Entities
 ┃ ┃ ┣ 📜 Product.cs
 ┃ ┣ 📂 Events
 ┃ ┃ ┣ 📜 ProductCreatedEvent.cs
 ┃ ┣ 📂 Interfaces
 ┃ ┃ ┣ 📜 IProductRepository.cs
 ┃ ┃ ┣ 📜 IEventStore.cs
 ┣ 📂 Infrastructure
 ┃ ┣ 📂 Persistence
 ┃ ┃ ┣ 📜 ApplicationDbContext.cs
 ┃ ┃ ┣ 📜 ProductRepository.cs
 ┃ ┃ ┣ 📜 EventStoreService.cs

📂 SampleCQRSProject.Tests
 ├── 📂 Repositories
 │    ├── ProductRepositoryTests.cs
 ├── 📂 Application
 │    ├── CreateProductCommandHandlerTests.cs
 ├── 📂 Controllers
 │    ├── ProductControllerTests.cs


🧪 Running Tests
1️⃣ Run all tests:
dotnet test

2️⃣ Check test results:
dotnet test --logger "console;verbosity=detailed"

👤 Author
Mohammad Javad Amankhani
📧 Contact: mohammadjavad.amankhani@gmail.com
🔗 www.linkedin.com/in/mohammadjavad-amankhani
