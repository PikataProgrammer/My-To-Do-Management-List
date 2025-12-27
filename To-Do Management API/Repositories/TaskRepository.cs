using Microsoft.EntityFrameworkCore;
using To_Do_Management_API.Data;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;

namespace To_Do_Management_API.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;
    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<TodoTask>> GetAllAsync(int offset, int limit)
    {
        return await _context.TodoTasks
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<TodoTask?> GetByIdAsync(int id)
    {
        return await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(TodoTask taskModel)
    {
        await _context.TodoTasks.AddAsync(taskModel);
    }

    public async Task<TodoTask?> DeleteAsync(int id)
    {
        var existingTask = await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id);
        if (existingTask == null)
        {
            return null;
        }
        
        _context.TodoTasks.Remove(existingTask);
        await _context.SaveChangesAsync();
        return existingTask;
    }

    public Task SaveChangesAsync()
    {
        return  _context.SaveChangesAsync();
    }
}