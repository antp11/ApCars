# ApCars – Desktop Application

Desktop application for managing a car dealership: vehicles, clients, sales and invoicing. Built with C# and .NET Framework (Windows Forms) on a SQL Server database.

## Features
- User login with role-based access
- CRUD management for vehicles, clients, brands, styles and users
- Invoicing with PDF reports and QR code generation
- Currency conversion (USD / CRC) using the Central Bank of Costa Rica (BCCR) web service
- Client lookup through the Costa Rican Ministry of Finance (Hacienda) API
- Sales charts and invoice reports
- Error logging with log4net

## Architecture
Layered architecture with interfaces:
- **UI** – Windows Forms
- **BLL** – Business logic
- **DAL** – Data access (SQL Server)

## Tech stack
C# · .NET Framework 4.8 · Windows Forms · SQL Server · log4net

## Screenshots
<img width="800"  alt="Home" src="https://github.com/user-attachments/assets/c100bbb1-a574-4261-9e14-fceb0289a924" />

<img width="800" alt="CRUD" src="https://github.com/user-attachments/assets/251f58f0-e94e-4342-9e74-a27f73fec603" />

## How to run
1. Restore the `APCAR` database in SQL Server.
2. Update the connection string in `App.config` if needed.
3. Open the solution in Visual Studio and run the project.

## Author
Anthony Pérez Álvarez – [LinkedIn](https://www.linkedin.com/in/anthony-perez-alvarez)
