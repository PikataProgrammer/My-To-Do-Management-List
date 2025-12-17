

namespace To_Do_Management_API.Entities;

public class TodoTask
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Pending"; // Pending, InProgress, Done
    public string Priority { get; set; } = "Medium"; // Low, Medium, High

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}