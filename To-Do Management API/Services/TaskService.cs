using To_Do_Management_API.Data;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;

namespace To_Do_Management_API.Services;

public class TaskService : ITaskRepository
{
    private readonly ApplicationDbContext _context;
    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<List<TodoTask>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TodoTask?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TodoTask> CreateAsync(TodoTask taskModel)
    {
        throw new NotImplementedException();
    }

    public Task<TodoTask?> UpdateAsync(int id, TodoTask taskModel)
    {
        throw new NotImplementedException();
    }

    public Task<TodoTask?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}