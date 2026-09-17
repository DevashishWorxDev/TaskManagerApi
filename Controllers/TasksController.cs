using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Models;
using TaskManagerApi.Repositories;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    // GET /api/tasks?isCompleted=false&priority=High
    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAll(
        [FromQuery] bool? isCompleted,
        [FromQuery] TaskPriority? priority)
    {
        return Ok(_repository.GetAll(isCompleted, priority));
    }

    [HttpGet("{id:int}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = _repository.GetById(id);
        return task is null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> Create(TaskItem task)
    {
        var created = _repository.Add(task);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, TaskItem task)
    {
        return _repository.Update(id, task) ? NoContent() : NotFound();
    }

    [HttpPatch("{id:int}/complete")]
    public IActionResult MarkCompleted(int id)
    {
        return _repository.MarkCompleted(id) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return _repository.Delete(id) ? NoContent() : NotFound();
    }
}
