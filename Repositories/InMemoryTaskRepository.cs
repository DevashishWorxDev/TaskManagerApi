using System.Collections.Concurrent;
using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories;

// Simulates a database table using a thread-safe dictionary.
// Data is lost when the app restarts.
public class InMemoryTaskRepository : ITaskRepository
{
    private readonly ConcurrentDictionary<int, TaskItem> _tasks = new();
    private int _nextId = 0;

    public InMemoryTaskRepository()
    {
        Add(new TaskItem { Title = "Learn git basics", Description = "init, add, commit, log", Priority = TaskPriority.High });
        Add(new TaskItem { Title = "Practise branching", Description = "branch, switch, merge", Priority = TaskPriority.Medium });
        Add(new TaskItem { Title = "Push to GitHub", Description = "remote, push, pull request", Priority = TaskPriority.Low });
    }

    public IEnumerable<TaskItem> GetAll(bool? isCompleted = null, TaskPriority? priority = null)
    {
        IEnumerable<TaskItem> query = _tasks.Values;

        if (isCompleted is not null)
            query = query.Where(t => t.IsCompleted == isCompleted);

        if (priority is not null)
            query = query.Where(t => t.Priority == priority);

        return query.OrderBy(t => t.Id);
    }

    public TaskItem? GetById(int id) => _tasks.GetValueOrDefault(id);

    public TaskItem Add(TaskItem task)
    {
        task.Id = Interlocked.Increment(ref _nextId);
        task.CreatedAt = DateTime.UtcNow;
        _tasks[task.Id] = task;
        return task;
    }

    public bool Update(int id, TaskItem task)
    {
        if (!_tasks.TryGetValue(id, out var existing))
            return false;

        existing.Title = task.Title;
        existing.Description = task.Description;
        existing.IsCompleted = task.IsCompleted;
        existing.Priority = task.Priority;
        return true;
    }

    public bool MarkCompleted(int id)
    {
        if (!_tasks.TryGetValue(id, out var existing))
            return false;

        existing.IsCompleted = true;
        return true;
    }

    public bool Delete(int id) => _tasks.TryRemove(id, out _);
}
