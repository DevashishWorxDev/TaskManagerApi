using TaskManagerApi.Models;

namespace TaskManagerApi.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAll();
    TaskItem? GetById(int id);
    TaskItem Add(TaskItem task);
    bool Update(int id, TaskItem task);
    bool Delete(int id);
}
