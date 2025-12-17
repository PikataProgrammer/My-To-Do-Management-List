using System.Xml.Serialization;
using To_Do_Management_API.Dtos.UserDto;
using To_Do_Management_API.Entities;

namespace To_Do_Management_API.Mappers;

public static class UserMapper
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Tasks =  user.Tasks
        };
    }

    public static User ToUserFromCreateUserDto(this CreateUserRequestDto userDto)
    {
        return new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
        };
    }

    public static User ToUserFromUpdateUserDto(this UpdateUserRequestDto userDto)
    {
        return new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
        };
    }
}