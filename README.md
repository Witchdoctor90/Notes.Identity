# Notes.Identity

Notes.Identity is an identity server designed specifically for the Notes managing application. It provides robust user authentication and authorization services to secure the main Notes backend.

---

## Overview

This project operates as a standalone identity management service implementing user registration, login, JSON Web Token (JWT) generation, and secure access control. It is architected to handle all aspects of user identity, including password management and token issuance, allowing the Notes backend application to focus purely on business logic related to notes management.

---

## Key Features

- User authentication and registration functionality.
- JWT token generation with user-specific claims for secure API access.
- ASP.NET Core Identity integration for user and role management.
- Secure password handling and validation.
- Token lifetime, issuer, and audience configuration.
- Middleware and controllers structured for extendability.
- Clear separation from Notes backend for modular microservice-style architecture.

---

## Technologies and Libraries

- **ASP.NET Core**: Foundation for building web applications and APIs.
- **ASP.NET Core Identity**: Framework for handling user authentication and management.
- **JWT (JSON Web Tokens)**: For issuing secure, signed tokens used in stateless authentication.
- **Entity Framework Core**: ORM used for user data persistence.
- **Microsoft IdentityModel.Tokens**: For token creation and validation.
- **MediatR**: Facilitates clean separation in command and query processing.
- **C# and .NET 8**: Primary programming language and platform.

---

## How It Works

- Users register through the identity server by providing credentials.
- Passwords and authentication data are securely handled using identity framework hashing and validation.
- Upon successful login, users receive a JWT token signed with a symmetric key.
- The token contains claims such as username and user ID, used to authorize requests to the Notes backend.
- Token expiration, validation parameters, and key management are configurable via application settings.
- The identity server exposes API endpoints for registration and login requests.

---

## API Endpoints

| Method | URL              | Description                  |
|--------|------------------|------------------------------|
| POST   | /auth/register   | Registers a new user          |
| POST   | /auth/login      | Authenticates user and returns JWT token |

---

## Security Considerations

- Uses industry-standard protocols and libraries for identity and access management.
- Passwords stored securely with hashing.
- Tokens issued with expiration and signing keys to ensure validity.
- Application settings control key parameters for token validation.

---

## Setup and Running

1. Clone the repository:
      
   ` git clone https://github.com/Witchdoctor90/Notes.Identity.git `  
   ` cd Notes.Identity `  

2. Configure database connection and JWT settings in `appsettings.json`.
3. Build and run the identity server:
   
   ` dotnet run --project Notes.Identity `

---

## Contribution

Contributions are welcome to improve security features, add functionality, or enhance documentation. Please open issues or submit pull requests.

---

## License

MIT License — see LICENSE file for details.

---
