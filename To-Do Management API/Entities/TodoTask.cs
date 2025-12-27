

using To_Do_Management_API.Dtos.TaskDto;

namespace To_Do_Management_API.Entities;

public class TodoTask
{
    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    
    public string Status { get; private set; }  // Pending, InProgress, Done
    public string Priority { get; private set; } // Low, Medium, High

    public DateTime CreatedAt { get; private set; }
    public DateTime? DueDate { get; private set; }

    public int UserId { get; private set; }
    public User? User { get; private set; }
    
    private TodoTask(){}

    public TodoTask(CreateTaskRequestDto dto)
    {
        CreatedAt = DateTime.UtcNow;
        Title = dto.Title;
        Description = dto.Description;
        Status = dto.Status;
        Priority = dto.Priority;
        DueDate = dto.DueDate;
        UserId = dto.UserId;
    }

    public void Update(UpdateTaskRequestDto dto)
    {
        Title = dto.Title;
        Description = dto.Description;
        Status = dto.Status;
        Priority = dto.Priority;
        DueDate = dto.DueDate;
    }
}