# TaskManagerApi

A small ASP.NET Core (.NET 9) Web API for practising git and GitHub.
Data is kept in an in-memory dictionary (no real database), so it resets on every restart.

## Run

```
dotnet run
```

Then open `TaskManagerApi.http` in VS Code / Visual Studio, or call `http://localhost:5156/api/tasks`.

## Endpoints

| Method | Route             | Description       |
|--------|-------------------|-------------------|
| GET    | /api/tasks        | List all tasks    |
| GET    | /api/tasks/{id}   | Get one task      |
| POST   | /api/tasks        | Create a task     |
| PUT    | /api/tasks/{id}   | Update a task     |
| DELETE | /api/tasks/{id}   | Delete a task     |
