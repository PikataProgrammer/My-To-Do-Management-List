using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using To_Do_Management_API.Data;
using To_Do_Management_API.Dtos.LoginDto;
using To_Do_Management_API.Dtos.UserDto;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;

namespace To_Do_Management_API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly  IConfiguration _configuration;
    public UserService(IUserRepository userRepository, ITaskRepository taskRepository, IConfiguration configuration)
    {
       _userRepository = userRepository;
       _taskRepository = taskRepository;
       _configuration = configuration;
    }

    public async Task<List<UserDto>> GetAllUsers(int? offset, int? limit)
    {
        int safeOffset = offset ?? 0;
        int safeLimit = limit ?? 10;

        if (safeLimit > 50)
            safeLimit = 50;

        if (safeOffset < 0)
            safeOffset = 0;
        
        var users = await _userRepository.GetAllAsync(safeOffset, safeLimit);
        ArgumentNullException.ThrowIfNull(users);
        
        return users.Select(u => new UserDto(u)).ToList();
    }

    public async Task<string> RegisterUser(CreateUserRequestDto createUserRequestDto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(createUserRequestDto.Email);
        if (existingUser != null)
        {
            throw new Exception("Email already exists");
        }

        var user = new User(createUserRequestDto);
        
        await _userRepository.CreateAsync(user);
        await _userRepository.SaveChangesAsync();
        return "User created successfully";
    }

    public async Task<JwtSecurityToken> Login(LoginRequestDto loginRequestDto)
    {
        // var users = await _userRepository.GetAllAsync(null, null);
        var user = await _userRepository.GetByEmailAsync(loginRequestDto.Email);
        if(user == null ||  user.Password != loginRequestDto.Password)
        {
            throw new Exception("Invalid email or password");
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), //Storing the id in the token
            new Claim(JwtRegisteredClaimNames.Email, user.Email), //Storing the email in the token 
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //Remove chance to use token second time
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: creds
        );
        return token;
    }

    public async Task<UserDto> CreateUser(CreateUserRequestDto createUserRequestDto)
    {
        var user = new User(createUserRequestDto);
        await _userRepository.CreateAsync(user);
        await _userRepository.SaveChangesAsync();
        
        return new UserDto(user);
    }

    public async Task<UserDto> UpdateUser(int id, UpdateUserRequestDto updateUserRequestDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        ArgumentNullException.ThrowIfNull(user);
        
        user.Update(updateUserRequestDto);
        
        await  _userRepository.SaveChangesAsync();
        
        return new UserDto(user);
    }

    public async Task<UserDto> DeleteUser(int id)
    {
        var user = await _userRepository.DeleteAsync(id);
        ArgumentNullException.ThrowIfNull(user);
        await  _userRepository.SaveChangesAsync();
        
        return new UserDto(user);
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        ArgumentNullException.ThrowIfNull(user);
        
        return new UserDto(user);
    }

}