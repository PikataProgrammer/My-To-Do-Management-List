using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using To_Do_Management_API.Data;
using To_Do_Management_API.Dtos.LoginDto;
using To_Do_Management_API.Dtos.UserDto;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;
using To_Do_Management_API.Mappers;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace To_Do_Management_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // private readonly IConfiguration _configuration;
    // private readonly IUserRepository _userRepo;
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequestDto createUserRequestDto)
    {
        var message = await _userService.RegisterUser(createUserRequestDto);
        return Ok(new {message = $"{message}"});
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        var token = await _userService.Login(loginRequestDto);

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(int? offset, int? limit)
    {
        var response = await _userService.GetAllUsers(offset, limit);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _userService.GetUserById(id);
        return Ok(result);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequestDto createUserRequestDto)
    {
        var response = await _userService.CreateUser(createUserRequestDto);

        return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
    {
        var response = await _userService.UpdateUser(id, updateUserRequestDto);
        return Ok(response);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await _userService.DeleteUser(id);
        return Ok(response);
    }
}