[中文版](README_CN.md)

# Car Rental Management

An **ASP.NET Core Blazor Interactive Server** web application for managing a car rental business. Built with C#, Entity Framework Core, and SQL Server.

---

## Tech Stack

| Layer | Technology | Version |
|-------|-----------|---------|
| Framework | ASP.NET Core (Blazor Interactive Server) | .NET 8.0 |
| Language | C# 12, HTML/Razor, CSS | — |
| ORM | Entity Framework Core | 8.0.11 |
| Database | SQL Server (LocalDB for development) | — |
| Authentication | ASP.NET Core Identity (Cookie + Roles) | 8.0.11 |
| UI | Blazor QuickGrid, Bootstrap 5 | — |

---

## Features

### Administration (Administrator Role)
- **Make Management** — CRUD for car brands (e.g., BMW, Toyota)
- **Model Management** — CRUD for car models (e.g., i4, Prius)
- **Colour Management** — CRUD for vehicle colours
- **Vehicle Management** — CRUD for vehicles with make/model/colour and license plate

### Operations (All Authenticated Users)
- **Customer Management** — CRUD for customers (driving license, address, contact, email)
- **Booking Management** — CRUD for rental bookings (check-out/in dates, vehicle, customer)

### General
- **User Registration & Login** with email confirmation
- **Role-based Authorization** — Administrator vs. regular users
- **Profile Management** — manage name, email, phone, password

---

## Architecture

```
┌──────────────────────────────────────────────┐
│            Blazor Components (UI)             │
│   Razor Pages with inline @code blocks       │
│   QuickGrid data tables, Bootstrap styling    │
└──────────────────┬───────────────────────────┘
                   │
┌──────────────────▼───────────────────────────┐
│     Entity Framework Core DbContext           │
│   CarRentalManagementContext                  │
└──────────────────┬───────────────────────────┘
                   │
┌──────────────────▼───────────────────────────┐
│            Domain Models (Entities)            │
│   Make, Model, Colour, Vehicle,              │
│   Customer, Booking (+ BaseDomainModel)       │
└──────────────────┬───────────────────────────┘
                   │
┌──────────────────▼───────────────────────────┐
│          SQL Server (LocalDB) Database         │
│   + ASP.NET Identity Tables                   │
└──────────────────────────────────────────────┘
```

---

## Domain Models

```
BaseDomainModel (abstract)
├── Id, DateCreated, DateUpdated, CreatedBy, UpdatedBy

Make (Id, Name) ─────────────┐
Model (Id, Name) ────────────┼──→ Vehicle
Colour (Id, Name) ───────────┘    ├── Id
                                   ├── LicensePlateNumber
                                   ├── MakeId, ModelId, ColourId

Customer                           Booking
├── Id                             ├── Id
├── DrivingLicense                 ├── DateOut, DateIn
├── Address                        ├── VehicleId, CustomerId
├── ContactNumber
└── EmailAddress

CarRentalManagementUser : IdentityUser
├── FirstName
└── LastName
```

---

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb) (included with Visual Studio)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommended) or any code editor

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/BoooSAMA/CarRentalManagement.git
cd CarRentalManagement
```

### 2. Restore Dependencies & Update Database

```bash
cd CarRentalManagement
dotnet restore
dotnet ef database update
```

Or in Visual Studio's Package Manager Console:

```
Update-Database
```

### 3. Run the Application

```bash
dotnet run
```

Or press `F5` in Visual Studio.

The app starts at:
- HTTP: `http://localhost:5085`
- HTTPS: `https://localhost:7054`

---

## Default Admin Account

On first run, the database seeder creates this account:

| Role | Email | Password |
|------|-------|----------|
| Administrator | `admin@localhost.com` | `P@ssword1` |

> ⚠️ **Important**: Change the admin password immediately in production. The password and hash are hardcoded in the source code (`Configuration/Entities/UserSeed.cs` and the `SeedUserRole` migration).

---

## Project Structure

```
CarRentalManagement/
├── CarRentalManagement.slnx              # Solution file
│
└── CarRentalManagement/                  # Main project
    ├── Program.cs                        # Entry point, DI, middleware
    ├── appsettings.json                  # Connection string config
    │
    ├── Domain/                           # Entity models
    │   ├── BaseDomainModel.cs            # Abstract base with audit fields
    │   ├── Make.cs                       # Car brand
    │   ├── Model.cs                      # Car model
    │   ├── Colour.cs                     # Vehicle colour
    │   ├── Vehicle.cs                    # Vehicle
    │   ├── Customer.cs                   # Customer
    │   └── Booking.cs                    # Rental booking
    │
    ├── Data/                             # EF Core layer
    │   ├── CarRentalManagementContext.cs # DbContext
    │   └── CarRentalManagementUser.cs    # Custom IdentityUser
    │
    ├── Configuration/Entities/           # Seed data
    │   ├── MakeSeed.cs                   # BMW, Toyota
    │   ├── ModelSeed.cs                  # i4, X5, Prius, C-HR
    │   ├── ColourSeed.cs                 # Black, Blue
    │   ├── UserSeed.cs                   # Default admin user
    │   ├── UserRoleSeed.cs               # Role assignment
    │   └── RoleSeed.cs                   # Roles: Admin, User
    │
    ├── Migrations/                       # EF Core migrations (5)
    │
    ├── Components/                       # Blazor UI
    │   ├── Layout/
    │   │   ├── MainLayout.razor          # Sidebar layout
    │   │   └── NavMenu.razor             # Auth-aware navigation
    │   ├── Pages/
    │   │   ├── Home.razor                # Landing page
    │   │   ├── AdminPages/               # Admin CRUD (Make/Model/Colour/Vehicle)
    │   │   ├── CustomerPages/            # Customer CRUD
    │   │   └── BookingPages/             # Booking CRUD
    │   └── Account/                      # Identity pages (Login, Register, etc.)
    │
    └── wwwroot/                          # Static assets (CSS, Bootstrap, favicon)
```

---

## Routes

| Route | Page | Access |
|-------|------|--------|
| `/` | Home | Public |
| `/makes` | Make List | Administrator |
| `/models` | Model List | Administrator |
| `/colours` | Colour List | Administrator |
| `/vehicles` | Vehicle List | Administrator |
| `/customers` | Customer List | Any Authenticated |
| `/bookings` | Booking List | Any Authenticated |
| `/Account/Login` | Login | Public |
| `/Account/Register` | Register | Public |
| `/Account/Manage` | Profile | Authenticated |

---

## Database Migrations

| Migration | Date | Change |
|-----------|------|--------|
| `Initial` | Nov 30, 2025 | Base schema + Identity tables |
| `SeedData` | Nov 30, 2025 | Seed Colour data |
| `AddIdentity` | Nov 30, 2025 | Seed Make + Model, rename table |
| `SeedUserRole` | Nov 30, 2025 | Seed roles, users, assignments |

---

## Security Notes

- 🔴 **Hardcoded admin credentials** in `UserSeed.cs` and the `SeedUserRole` migration. Change before production use.
- 🟡 **No email sender configured** (`IdentityNoOpEmailSender`) — email confirmation & password reset emails will not actually send.
- 🟡 **LocalDB only** — no production database connection string configured.
- 🟡 **Missing FK navigation properties** — vehicle and booking foreign keys lack explicit relationships in the domain models.
- 🟢 **Antiforgery enabled** — CSRF protection is active.
- 🟢 **HSTS configured** — HTTPS enforced in non-development environments.

---

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
