using To_Do_Management_API.Dtos.TaskDto;
using To_Do_Management_API.Entities;

namespace To_Do_Management_API.Dtos.UserDto;

public class UserDto
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public List<TaskDto.TaskDto> Tasks { get; private set; }

    public UserDto(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        Tasks = user.Tasks.Select(t => new TaskDto.TaskDto(t)).ToList();
    }
}
