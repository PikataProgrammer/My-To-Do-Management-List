using To_Do_Management_API.Dtos.UserDto;

namespace To_Do_Management_API.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public List<TodoTask> Tasks { get; set; } = new();
    
    private User(){}

    public User(CreateUserRequestDto createUserRequestDto)
    {
        Name = createUserRequestDto.Name;
        Email = createUserRequestDto.Email;
        Password = createUserRequestDto.Password;
    }

    public void Update(UpdateUserRequestDto updateUserRequestDto)
    {
        Name = updateUserRequestDto.Name;
        Email = updateUserRequestDto.Email;
        Password = updateUserRequestDto.Password;
    }

}