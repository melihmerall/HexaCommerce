# 🚀 HexaCommerce - Enterprise Multi-Store E-Commerce Platform

<div align="center">

![HexaCommerce Logo](https://img.shields.io/badge/HexaCommerce-Enterprise%20E--Commerce-blue?style=for-the-badge&logo=shopping-cart)
![.NET 8](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge&logo=dotnet)
![Vue.js 3](https://img.shields.io/badge/Vue.js-3.0-green?style=for-the-badge&logo=vue.js)
![License](https://img.shields.io/badge/License-Proprietary-red?style=for-the-badge)

**Enterprise-level multi-store e-commerce platform with Clean Architecture, SOLID principles, and modern technologies.**

[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen?style=for-the-badge)](https://github.com/hexacommerce/hexacommerce)
[![Code Coverage](https://img.shields.io/badge/Code%20Coverage-85%25-brightgreen?style=for-the-badge)](https://github.com/hexacommerce/hexacommerce)
[![Security](https://img.shields.io/badge/Security-Audited-brightgreen?style=for-the-badge)](https://github.com/hexacommerce/hexacommerce)

</div>

## 📋 Table of Contents

- [🚀 Features](#-features)
- [🏗️ Architecture](#️-architecture)
- [🛠️ Technology Stack](#️-technology-stack)
- [📦 Prerequisites](#-prerequisites)
- [⚡ Quick Start](#-quick-start)
- [🔧 Configuration](#-configuration)
- [📚 Documentation](#-documentation)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)
- [📞 Contact](#-contact)

## 🚀 Features

### 🏪 Multi-Store Management
- **Platform Admin Dashboard** - Centralized store management
- **Store Owner Dashboard** - Individual store administration
- **Multi-tenant Architecture** - Isolated databases per store
- **Store Customization** - Themes, branding, and settings

### 🛒 E-Commerce Features
- **Product Management** - Categories, variants, attributes
- **Inventory Management** - Real-time stock tracking
- **Order Management** - Complete order lifecycle
- **Customer Management** - Profiles, addresses, history
- **Payment Integration** - Stripe, PayPal, and more
- **Shipping Management** - Multiple carriers and methods

### 🔐 Security & Authentication
- **JWT Authentication** - Secure token-based auth
- **Role-based Authorization** - Granular permissions
- **Multi-factor Authentication** - Enhanced security
- **API Rate Limiting** - Protection against abuse
- **Audit Logging** - Complete activity tracking

### 📊 Analytics & Reporting
- **Sales Analytics** - Revenue and performance metrics
- **Customer Analytics** - Behavior and insights
- **Inventory Reports** - Stock and movement analysis
- **Real-time Dashboard** - Live business metrics

## 🏗️ Architecture

```
HexaCommerce/
├── 📁 src/
│   ├── 🏛️ HexaCommerce.Domain/          # Core business logic
│   │   ├── Entities/                    # Domain entities
│   │   ├── ValueObjects/                # Immutable value objects
│   │   ├── Events/                      # Domain events
│   │   ├── Services/                    # Domain services
│   │   ├── Specifications/              # Query specifications
│   │   └── Interfaces/                  # Repository interfaces
│   │
│   ├── ⚙️ HexaCommerce.Application/     # Application layer
│   │   ├── DTOs/                        # Data transfer objects
│   │   ├── Interfaces/                  # Application interfaces
│   │   ├── Commands/                    # CQRS commands
│   │   ├── Queries/                     # CQRS queries
│   │   ├── Validators/                  # FluentValidation
│   │   └── Mappings/                    # AutoMapper profiles
│   │
│   ├── 🔧 HexaCommerce.Infrastructure/  # External concerns
│   │   ├── Data/                        # Entity Framework
│   │   ├── Services/                    # External services
│   │   ├── Repositories/                # Repository implementations
│   │   └── Identity/                    # Authentication services
│   │
│   └── 🌐 HexaCommerce.API/             # Web API layer
│       ├── Controllers/                 # API endpoints
│       ├── Middleware/                  # Custom middleware
│       └── Filters/                     # Action filters
│
├── 🧪 tests/
│   ├── HexaCommerce.UnitTests/          # Unit tests
│   └── HexaCommerce.IntegrationTests/   # Integration tests
│
└── 📚 docs/                             # Documentation
```

## 🛠️ Technology Stack

### Backend
- **.NET 8** - Latest .NET framework
- **Clean Architecture** - Separation of concerns
- **CQRS + MediatR** - Command Query Responsibility Segregation
- **Entity Framework Core** - ORM with SQL Server
- **AutoMapper** - Object mapping
- **FluentValidation** - Input validation
- **JWT Authentication** - Secure authentication
- **Serilog** - Structured logging

### Frontend (Coming Soon)
- **Vue.js 3** - Progressive JavaScript framework
- **TypeScript** - Type-safe JavaScript
- **Vite** - Fast build tool
- **Pinia** - State management
- **Vue Router** - Client-side routing
- **Tailwind CSS** - Utility-first CSS

### Infrastructure
- **SQL Server** - Primary database
- **Redis** - Caching and sessions
- **RabbitMQ** - Message queuing
- **Elasticsearch** - Search engine
- **Docker** - Containerization
- **Azure/AWS** - Cloud deployment

## 📦 Prerequisites

- **.NET 8 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server 2022** - [Download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Redis** - [Download](https://redis.io/download)
- **Docker Desktop** - [Download](https://www.docker.com/products/docker-desktop)

## ⚡ Quick Start

### 1. Clone Repository
```bash
git clone https://github.com/hexacommerce/hexacommerce.git
cd hexacommerce
```

### 2. Setup Database
```bash
# Update connection string in appsettings.json
# Run migrations
dotnet ef database update --project src/HexaCommerce.Infrastructure
```

### 3. Run Application
```bash
# Restore packages
dotnet restore

# Build solution
dotnet build

# Run API
dotnet run --project src/HexaCommerce.API
```

### 4. Access Application
- **API**: https://localhost:7001
- **Swagger**: https://localhost:7001/swagger
- **Health Check**: https://localhost:7001/health

## 🔧 Configuration

### Environment Variables
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HexaCommerce;Trusted_Connection=true;"
  },
  "JwtSettings": {
    "SecretKey": "your-super-secret-key-here",
    "Issuer": "HexaCommerce",
    "Audience": "HexaCommerceUsers",
    "AccessTokenExpirationMinutes": 60,
    "RefreshTokenExpirationDays": 7
  },
  "Redis": {
    "ConnectionString": "localhost:6379"
  }
}
```

### Docker Setup
```bash
# Build and run with Docker Compose
docker-compose up -d

# Run individual services
docker run -d --name hexacommerce-api hexacommerce/api:latest
```

## 📚 Documentation

- **[API Documentation](docs/api.md)** - Complete API reference
- **[Architecture Guide](docs/architecture.md)** - Detailed architecture overview
- **[Deployment Guide](docs/deployment.md)** - Production deployment instructions
- **[Development Guide](docs/development.md)** - Development setup and guidelines

## 🤝 Contributing

**⚠️ IMPORTANT: This is proprietary software. Please read our license before contributing.**

### Development Setup
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Code Standards
- Follow **SOLID principles**
- Write **unit tests** for new features
- Use **meaningful commit messages**
- Follow **C# coding conventions**
- Document **public APIs**

## 📄 License

This project is licensed under a **Proprietary License** - see the [LICENSE](LICENSE) file for details.

**⚠️ Commercial use is strictly prohibited without written permission.**

## 📞 Contact

- **Website**: https://hexacommerce.com
- **Email**: contact@hexacommerce.com
- **GitHub**: https://github.com/hexacommerce
- **LinkedIn**: https://linkedin.com/company/hexacommerce

---

<div align="center">

**Built with ❤️ by the HexaCommerce Team**

[![GitHub stars](https://img.shields.io/github/stars/hexacommerce/hexacommerce?style=social)](https://github.com/hexacommerce/hexacommerce)
[![GitHub forks](https://img.shields.io/github/forks/hexacommerce/hexacommerce?style=social)](https://github.com/hexacommerce/hexacommerce)
[![GitHub issues](https://img.shields.io/github/issues/hexacommerce/hexacommerce)](https://github.com/hexacommerce/hexacommerce/issues)

</div> 