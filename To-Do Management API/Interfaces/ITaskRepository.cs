using To_Do_Management_API.Entities;

namespace To_Do_Management_API.Interfaces;

public interface ITaskRepository
{
    public Task<List<TodoTask>> GetAllAsync();
    public Task<TodoTask?> GetByIdAsync(int id);
    public Task<TodoTask> CreateAsync(TodoTask taskModel);
    public Task<TodoTask?> UpdateAsync(int id, TodoTask taskModel);
    public Task<TodoTask?> DeleteAsync(int id);
}