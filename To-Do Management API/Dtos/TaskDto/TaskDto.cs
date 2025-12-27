using To_Do_Management_API.Entities;
namespace To_Do_Management_API.Dtos.TaskDto;

public class TaskDto
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public string Status { get; private set; } 
    public string Priority { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? DueDate { get; private set; }

    public int UserId { get; private set; }

    public TaskDto(TodoTask todoTask)
    {
        Id =  todoTask.Id;
        Title = todoTask.Title;
        Description = todoTask.Description;
        Status = todoTask.Status;
        Priority = todoTask.Priority;
        CreatedAt = todoTask.CreatedAt;
        DueDate = todoTask.DueDate;
        UserId = todoTask.UserId;
    }
}