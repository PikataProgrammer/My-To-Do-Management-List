using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_Management_API.Data;
using To_Do_Management_API.Dtos.UserDto;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;
using To_Do_Management_API.Mappers;

namespace To_Do_Management_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    public UserController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepo.GetAllAsync();
        if (users == null)
        {
            return NotFound();
        }
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user.ToUserDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequestDto dto)
    {
        var userModel = dto.ToUserFromCreateUserDto();
        await _userRepo.CreateAsync(userModel);

        return CreatedAtAction(nameof(GetUserById), new { id = userModel.Id }, userModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserRequestDto dto)
    {
        
    }
}