using System.ComponentModel.DataAnnotations;
using To_Do_Management_API.Entities;
namespace To_Do_Management_API.Dtos.TaskDto;

public class CreateTaskRequestDto
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Description is required")]
    [MinLength(10, ErrorMessage = "Description must be at least 10 characters long")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Choose valid status - Pending, InProgress, Done")]
    public string Status { get; set; } = "Pending"; // "Pending", "InProgress", "Done"
    [Required(ErrorMessage = "Choose valid priority - Low, Medium, High")]
    public string Priority { get; set; } = "Medium"; // "Low", "Medium", "High"
    
    public DateTime? DueDate { get; set; }
    public int UserId { get; set; } 
    
}