using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAll(bool? isCompleted = null, TaskPriority? priority = null);
    TaskItem? GetById(int id);
    TaskItem Add(TaskItem task);
    bool Update(int id, TaskItem task);
    bool MarkCompleted(int id);
    bool Delete(int id);
}
