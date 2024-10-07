<div align="center">
<h1> Unlock New Opportunities - Shape Your Success -  Explore Our Innovative Training Platform! 🌟🎓📈</h1>
</div>

## Overview 💥
This system aims to enhance training management and communication between trainers and trainees within the company. It includes multiple interfaces to meet the needs of different users, such as trainers, trainees, and administrative supervisors (admins). The system features an easy-to-use interface and advanced functionalities to ensure a smooth and effective training experience.

## 🗂 Database Schema Design
<img width="923" alt="db" src="https://github.com/user-attachments/assets/11e1b4c1-e4f3-4bd8-9b0e-831cb548f344">

## Key Features 🌟
### 1. Admin Interface (Admin _ Team Lead)

User Management: Admins can add, edit, or delete users including trainers and students. This feature allows for efficient management of user roles and ensures that the right individuals have access to the appropriate resources.
Training Areas Management: Admins can create and manage different training areas, ensuring that all training programs are organized and easily accessible.
### 2. Trainer Interface

Resource Management: Trainers can add and update training materials, such as documents, links, and multimedia resources. This ensures that students have access to the most current and relevant materials for their learning.
Task Creation and Assessment: Trainers can create tasks and assessments that students need to complete, along with the ability to provide feedback and grades. This feature fosters accountability and encourages student engagement.
### 3. Student Interface

User Authentication: Students can securely log in to their accounts to access personalized content and resources. This promotes a safe and secure environment for learning.
Task Management: Students can receive, manage, and submit tasks through the platform, making it easier to track their progress and deadlines. This feature enhances organization and time management skills.
### 4. Authentication - Register/Login

User Registration: New users can easily register for an account, ensuring a smooth onboarding process.
Password Recovery: Users who forget their passwords can reset them easily, maintaining accessibility while ensuring security.
### 5. User Profiles

Profile Information: Each user has a profile containing basic information such as full name, email, phone number, profile picture, and social media links (GitHub/LinkedIn). This allows for personalized interactions and connections among users.
Field of Training: Trainees can specify their training areas, while trainers can indicate their specialties. This feature helps in matching students with appropriate training programs and resources.

## Layered architecture
`Clean Architecture`
It achieves this by separating the application into different layers that have distinct responsibilities:

![1_JWzL8VcHl13x0J5rDUZWzA](https://github.com/user-attachments/assets/22923e3a-db2b-4fc7-84a6-388908189879)


### 1. Domain Layer
Contains the core business logic and domain entities. This layer is independent of other layers and focuses on the business rules and domain models.
#### Components:
- Entities: Represent the core data models. For example, User, Role, Trainer, Trainee, Task.
- Value Objects: Define immutable objects used within the domain. For example, Address, Money.
- DTOs (Data Transfer Objects): Define the data structures used for communication between the application layer and the API layer. For example, UserDto, TaskDto.
- Domain Repository: Implement business logic that does not naturally fit within an entity. For example, FeedBackRepository.
### 2. Infrastructure Layer
Provides implementations for data access, external services, and other system-level concerns. This layer interacts with databases, file systems, and external APIs.
#### Components:
- Repositories: Implement data access logic and interact with the database. For example, UserRepository, TaskRepository.
- Data Context: Manages database connections and operations. For example, AppDbContext.
- Configurations: Manage configurations for external services and data access.
### 3. Application Layer
Orchestrates the application's workflow, coordinates interactions between domain models and infrastructure, and handles application-specific logic.
#### Components:
- Services: Implement application-specific logic and use domain services and repositories to perform operations. For example, UserService, TaskService.
- Application Interfaces: Define contracts for services and repositories. For example, IUserService, ITaskService.
 - External Services: Handle interactions with third-party services. For example, image storage services, payment gateways.
### 4. API Layer
Exposes endpoints for client interaction and handles HTTP requests and responses. This layer is responsible for routing, validation, and transforming data between the application layer and clients.
#### Components:
- Controllers: Handle incoming HTTP requests, invoke application services, and return responses. For example, UserController, FeedBackController.
- Middlewares: Implement cross-cutting concerns such as authentication, authorization, and logging.
- Response Handlers: Standardize API responses and error handling. For example, ResponseHandler.

## 🔋🪫 Testing Frameworks 
Ensuring code quality and functionality with comprehensive testing suites using:

- ##### xUnit: A popular .NET testing framework that facilitates writing and executing unit tests with a focus on simplicity and extensibility. ✅
- ##### Moq: A powerful mocking library for .NET that allows creating mock objects for unit testing, enabling isolated and controlled test scenarios. 🧪
- ##### FluentAssertions: A library that provides a more expressive and readable syntax for assertions, making tests easier to write and understand. 📏
- ##### Fixture: A testing concept used to set up shared contexts for multiple test cases, allowing for efficient and consistent test execution. 🧩
<img width="318" alt="Screenshot 2024-10-06 212315" src="https://github.com/user-attachments/assets/ecac663a-bb92-4565-b3b6-8df35cccfdad">

## Design Patterns
In the TMS Platform, several design patterns are employed to ensure a clean, maintainable, and scalable architecture. Here’s a summary of the key patterns used:
### 1. Unit of Work Pattern
The Unit of Work pattern is used to manage changes to multiple entities in a single transaction. This pattern ensures that changes to the database are handled in a single unit, maintaining data consistency and integrity.

<img width="457" alt="Unitofwork" src="https://github.com/user-attachments/assets/a4007b80-a962-4fca-952e-d2bee8655f3c">

### 2. Generic Repository Pattern
The Generic Repository pattern provides a way to manage CRUD operations in a consistent and reusable manner. This pattern abstracts the data access layer and provides a generic implementation for common operations.

![layers](https://github.com/user-attachments/assets/2eded6b6-715e-415b-b7a3-63a4d17db03c)

## 🕰️ Project Management 
#### Use of Trello for Task Management
<img width="956" alt="Screenshot 2024-10-05 212322" src="https://github.com/user-attachments/assets/a62ffcf3-0f29-4647-b83c-93aca27a19ef">

## Setup Guide
#### **Clone the Repository**

```bash
git clone [https://github.com/Leen-odeh3/Travel-and-Accommodation-Booking-Platform.git](https://github.com/GSG-FinalProject/Training-Management-System-BackRepo)
cd Training-Management-System-BackRepo
```
#### 3. **Configure appsettings.json**
 Open the `appsettings.json` file located in your project directory and configure the connection string for SQL Server. 
 Replace the `<connection_string>` placeholder with your SQL Server connection string:
```{
  "ConnectionStrings": {
    "SqlServer": "<connection_string>"
  }
}
```
### 🤝 Contributors
This project is developed by an amazing team :
- <a href="https://github.com/Leen-odeh3">Leen odeh</a> 
- <a href="https://github.com/Shaima-AlKhader">Shaima AlKhader</a> 
- <a href="https://github.com/talamahmoud">Tala Mahmoud</a>
- <a href="https://github.com/LayanAlfar0">Layan Alfar</a>

## 📈 Proposal Document
You can view the proposal document 

[Market Ready Developer Training Program.pdf](https://github.com/user-attachments/files/17284392/Market.Ready.Developer.Training.Program.pdf)

## 🏅 Acknowledgements
I extend my sincere gratitude to <a href="https://gazaskygeeks.com/"> Gaza sky Geeks </a> for granting me the opportunity to participate in this internship during the <strong> Market Ready Developer Training program </strong>.
Their unwavering support has been instrumental throughout the development of this project.

Special thanks to those who provided mentorship to <strong>Saad Haroub</strong>, <strong>Osaid Makhalfih</strong>, <strong>Amin Eid</strong>, and <strong>Aseel Issa</strong> for their contributions to the success of this project. 

<div align="center">
<img src="https://github.com/user-attachments/assets/3de1ce60-bf1d-4eb1-a688-ea2d8265df03"/>

#### Thank you for your interest. I look forward to hearing from you! 🥳

</div>
