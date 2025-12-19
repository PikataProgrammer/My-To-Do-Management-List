using To_Do_Management_API.Dtos.TaskDto;

namespace To_Do_Management_API.Dtos.UserDto;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public List<TaskDto.TaskDto> Tasks { get; set; } = new();
}
