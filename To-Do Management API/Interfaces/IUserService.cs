using System.IdentityModel.Tokens.Jwt;
using To_Do_Management_API.Dtos.LoginDto;
using To_Do_Management_API.Dtos.UserDto;

namespace To_Do_Management_API.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task<List<UserDto>> GetAllUsers(int? offset, int? limit);
    Task<string> RegisterUser(CreateUserRequestDto createUserRequestDto);
    Task<JwtSecurityToken> Login(LoginRequestDto loginRequestDto);
    Task<UserDto> CreateUser(CreateUserRequestDto createUserRequestDto);
    Task<UserDto> UpdateUser(int id, UpdateUserRequestDto updateUserRequestDto);
    Task<UserDto> DeleteUser(int id);
}