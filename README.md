# TO DO API Project

## Overview

This project demonstrates a minimal API using .NET Core 8.0 for managing a to-do list. The API supports basic CRUD operations and is containerized using Docker.

## Prerequisites

- .NET Core 8.0 SDK
- Docker

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/campos2504/TodoApi
cd TodoApi
```

### Build and Run the API Locally

1. **Restore Dependencies**: 
    ```bash
    dotnet restore
    ```
2. **Run the Application**:
    ```bash
    dotnet run
    ```

### Using Docker

1. **Build the Docker Image**:
    ```bash
    docker build -t todoapi .
    ```
2. **Run the Docker Container**:
    ```bash
    docker run -d -p 8080:80 todoapi
    ```

## API Endpoints

### Get All To-Do Items

- **Endpoint**: `/todoitems`
- **Method**: `GET`
- **Description**: Retrieves all to-do items.
- **Response**: 
  ```json
  [
    {
      "id": 1,
      "name": "Item 1",
      "isComplete": false
    },
    {
      "id": 2,
      "name": "Item 2",
      "isComplete": true
    }
  ]
  ```

### Get To-Do Item by ID

- **Endpoint**: `/todoitems/{id}`
- **Method**: `GET`
- **Description**: Retrieves a specific to-do item by ID.
- **Response**:
  - **200 OK**: 
    ```json
    {
      "id": 1,
      "name": "Item 1",
      "isComplete": false
    }
    ```
  - **404 Not Found**

### Create a New To-Do Item

- **Endpoint**: `/todoitems`
- **Method**: `POST`
- **Description**: Creates a new to-do item.
- **Request Body**:
  ```json
  {
    "name": "New Item",
    "isComplete": false
  }
  ```
- **Response**:
  - **201 Created**: 
    ```json
    {
      "id": 3,
      "name": "New Item",
      "isComplete": false
    }
    ```

### Update a To-Do Item

- **Endpoint**: `/todoitems/{id}`
- **Method**: `PUT`
- **Description**: Updates an existing to-do item.
- **Request Body**:
  ```json
  {
    "id": 1,
    "name": "Updated Item",
    "isComplete": true
  }
  ```
- **Response**:
  - **204 No Content**
  - **400 Bad Request**
  - **404 Not Found**

### Delete a To-Do Item

- **Endpoint**: `/todoitems/{id}`
- **Method**: `DELETE`
- **Description**: Deletes a to-do item by ID.
- **Response**:
  - **204 No Content**
  - **404 Not Found**

## Running Tests

To run the tests, use the following command:

```bash
dotnet test
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

