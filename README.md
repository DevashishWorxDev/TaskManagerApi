# TaskManagerApi

A small ASP.NET Core (.NET 9) Web API for practising git and GitHub.
Data is kept in an in-memory dictionary (no real database), so it resets on every restart.

## Run

```
dotnet run
```

Then open `TaskManagerApi.http` in VS Code / Visual Studio, or call `http://localhost:5156/api/tasks`.

## Endpoints

| Method | Route                     | Description                          |
|--------|---------------------------|--------------------------------------|
| GET    | /api/tasks                | List tasks (optional filters below)  |
| GET    | /api/tasks/{id}           | Get one task                         |
| POST   | /api/tasks                | Create a task                        |
| PUT    | /api/tasks/{id}           | Update a task                        |
| PATCH  | /api/tasks/{id}/complete  | Mark a task as completed             |
| DELETE | /api/tasks/{id}           | Delete a task                        |

### Filters for `GET /api/tasks`

| Query parameter | Values                  | Example                  |
|-----------------|-------------------------|--------------------------|
| `isCompleted`   | `true`, `false`         | `?isCompleted=false`     |
| `priority`      | `Low`, `Medium`, `High` | `?priority=High`         |

## Task fields

| Field         | Type     | Notes                                      |
|---------------|----------|--------------------------------------------|
| `title`       | string   | Required, 1–100 characters                 |
| `description` | string   | Optional, up to 500 characters             |
| `isCompleted` | bool     | Defaults to `false`                        |
| `priority`    | string   | `Low`, `Medium` (default) or `High`        |
