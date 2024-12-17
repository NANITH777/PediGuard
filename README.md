# PediGuard: Pediatric Assistant Shift Management System

## 🏥 Project Overview

PediGuard is a comprehensive web application designed to streamline shift management and communication within a pediatric department, addressing complex organizational challenges for medical assistants and faculty. By automating and centralizing key processes such as on-call scheduling, department management, and emergency communication, PediGuard aims to improve efficiency and coordination across the pediatric team.

The system provides an intuitive Admin Panel for administrators to manage shift schedules, faculty details, department overviews, and emergency notifications. This data is seamlessly integrated into the User Panel, where medical assistants and faculty members can access relevant information, book appointments, and stay informed about urgent updates.

## 🌟 Key Features

### 1. Shift Management

- Organized shift scheduling for pediatric assistants
- Dedicated shifts for Emergencies
- 24-hour shift tracking system

### 2. User Interfaces

- **Admin Panel**:

  - Complete shift and user management
  - Emergency news management
  - Scheduling controls

- **User Panel**:
  - Calendar view of shifts
  - Department information
  - Appointment scheduling
  - On-call schedule of the assistants.

### 3. Advanced Functionalities

- Appointment booking system
- Emergency communication platform
- Detailed profiles for assistants and faculty members(Doctors)
- Department information pages
- Doctors' Availability

## 🛠 Technical Stack

### Backend

- **Framework**: ASP.NET MVC Core 8.0
- **ORM**: Entity Framework Core
- **Architecture**: Code First Approach
- **Authentication**: ASP.NET Core Identity
- **Design Pattern**: Repository Pattern
- **Validation**: Data Annotations, Custom Validation

### Frontend

- **Languages**: HTML5, CSS3, JavaScript
- **Styling**:
  - Bootstrap 5
  - Responsive Design
  - Flexbox Layout
- **Libraries**:
  - jQuery
  - Select2
  - FullCalendar.js

### Database

- **Database**: SQL Server
- **Approach**: Code First Migration
- **Minimum Tables**: 8 interconnected entities
- **Relationships**: One-to-Many, Many-to-Many

### Additional Technologies

- **Dependency Injection**: Built-in .NET Core DI
- **Logging**: Identity
- **SendGrid** : Sending Emails

## 🎯 Project Goals

- Enhance communication in medical departments
- Simplify shift management processes
- Provide transparent scheduling for assistants

## 🔒 Security Features

- Role-based access control
- Secure admin panel
- HTTPS encryption
- Input validation and sanitization

## 🚀 Getting Started

1. Clone the repository
2. Install .NET 8.0 SDK
3. Configure `appsettings.json`
4. Run database migrations
5. Launch the application

### Prerequisites

- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 (recommended)

## 📦 Installation

```bash
# Clone the repository
git clone https://github.com/NANITH777/PediGuard.git

# Navigate to project directory
cd PediGuard

# Restore dependencies
dotnet restore

# Update database
dotnet ef database update

# Run the application
dotnet run
```

## 👥 Contributors

[[Nanith](https://github.com/NANITH777)] - Lead Developer
