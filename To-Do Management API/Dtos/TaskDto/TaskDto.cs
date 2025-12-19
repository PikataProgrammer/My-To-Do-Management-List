using To_Do_Management_API.Entities;
namespace To_Do_Management_API.Dtos.TaskDto;

public class TaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Pending";
    public string Priority { get; set; } = "Medium";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? DueDate { get; set; }

    public int UserId { get; set; }
}