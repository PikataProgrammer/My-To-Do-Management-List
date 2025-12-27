using System.ComponentModel.DataAnnotations;

namespace To_Do_Management_API.Dtos.UserDto;

public class CreateUserRequestDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}