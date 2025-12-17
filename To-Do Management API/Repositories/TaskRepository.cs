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
    
    public async Task<List<TodoTask>> GetAllAsync()
    {
        return await _context.TodoTasks.ToListAsync();
    }

    public async Task<TodoTask?> GetByIdAsync(int id)
    {
        var todoTask = await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id);
        return todoTask;
    }

    public async Task<TodoTask> CreateAsync(TodoTask taskModel)
    {
        await _context.TodoTasks.AddAsync(taskModel);
        await _context.SaveChangesAsync();
        return taskModel;
    }

    public async Task<TodoTask?> UpdateAsync(int id, TodoTask taskModel)
    {
        var todoTask = await _context.TodoTasks.FirstOrDefaultAsync(x => x.Id == id);
        if (todoTask == null)
        {
            return null;
        }
         todoTask.Title = taskModel.Title;
         todoTask.Description = taskModel.Description;
         todoTask.Status = taskModel.Status;
         todoTask.Priority = taskModel.Priority;
         todoTask.CreatedAt = taskModel.CreatedAt;
         todoTask.DueDate = taskModel.DueDate;
         
         await _context.SaveChangesAsync();
         return todoTask;
    }

    public async Task<TodoTask?> DeleteAsync(int id)
    {
        var existingTask = await _context.TodoTasks.FindAsync(id);
        if (existingTask == null)
        {
            return null;
        }
        
        _context.TodoTasks.Remove(existingTask);
        await _context.SaveChangesAsync();
        return existingTask;
    }
}