using To_Do_Management_API.Entities;

namespace To_Do_Management_API.Interfaces;

public interface ITaskRepository
{
    public Task<List<TodoTask>> GetAllAsync(int offset, int limit);
    public Task<TodoTask?> GetByIdAsync(int id);
    public Task CreateAsync(TodoTask taskModel);
    public Task<TodoTask?> DeleteAsync(int id);
    public Task SaveChangesAsync();
}