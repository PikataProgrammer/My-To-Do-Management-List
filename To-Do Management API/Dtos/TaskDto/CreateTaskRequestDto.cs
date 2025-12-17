using To_Do_Management_API.Entities;
namespace To_Do_Management_API.Dtos.TaskDto;

public class CreateTaskRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Pending"; // "Pending", "InProgress", "Done"
    public string Priority { get; set; } = "Medium"; // "Low", "Medium", "High"
    
    public DateTime? DueDate { get; set; }
    
}