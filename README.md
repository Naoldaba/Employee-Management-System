# Employee Management System API

This is a .NET Core-based RESTful API designed for managing employee data within an organization. It supports CRUD operations for handling employee records and utilizes PostgreSQL for the database. The project follows the repository pattern for efficient data access and separation of concerns.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete employee records.
- **Repository Pattern**: Clean separation between data access and business logic.
- **Relational Database**: PostgreSQL is used for persistent storage.

## Technologies Used

- .NET Core
- Entity Framework Core
- PostgreSQL
- Repository Pattern
- Swagger for API Documentation

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

## Setup and Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/Naoldaba/Employee-Management-System.git
    cd Employee-Management-System
    ```

2. Set up your environment variables:

    Create a `.env` file in the root directory of your project with the following content:

    ```plaintext
    DB_CONNECTION_STRING = Host=<host>;Database=<db_name>;Username=<username>;Password=<password>
    SECRET_KEY = <your secret key>
    ```

3. Install dependencies:

    ```bash
    dotnet restore
    ```

4. Apply migrations to set up the database:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. Run the application:

    ```bash
    dotnet run
    ```

6. The application will start on https://localhost:7149 or http://localhost:5261 by default based on your preference.

## API Endpoints

### Employees

- **GET /employees**: Retrieves a list of all employees.
    - Example response:

        ```json
        [
            {
                "id": 1,
                "firstName": "Naol",
                "middleName": "D",
                "lastName": "Mulleta"
            }
        ]
        ```

- **GET /employees/{id}**: Fetches details of a specific employee by ID.
    - Example response:

        ```json
        {
            "id": 1,
            "firstName": "Naol",
            "middleName": "D",
            "lastName": "Mulleta"
        }
        ```

- **POST /employees**: Creates a new employee.
    - Request body:

        ```json
        {
            "firstName": "Naol",
            "middleName": "D",
            "lastName": "Mulleta"
        }
        ```

- **PUT /employees/{id}**: Updates an existing employee's information by ID.
    - Request body:

        ```json
        {
            "firstName": "Hawi",
            "middleName": "",
            "lastName": "Feyissa"
        }
        ```

- **DELETE /employees/{id}**: Deletes an employee by their ID.

### Swagger Documentation

Swagger is available for exploring and testing the API endpoints. It can be access via:

- `http://localhost:5261/swagger`