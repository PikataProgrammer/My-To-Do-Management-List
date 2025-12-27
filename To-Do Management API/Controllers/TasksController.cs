using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_Management_API.Data;
using To_Do_Management_API.Dtos.LoginDto;
using To_Do_Management_API.Dtos.TaskDto;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;
using To_Do_Management_API.Mappers;

namespace To_Do_Management_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    // private readonly ITaskRepository _taskRepo;
    // private readonly IUserRepository _userRepo;
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }


    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetTasksByUserId(int userId)
    {
        var tasks = await _taskService.GetAllTasks(null, null);
        var userTasks = tasks.Where(x => x.UserId == userId).ToList();
        return Ok(userTasks);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTasks(int? offset, int? limit)
    {
        var tasks = await _taskService.GetAllTasks(offset, limit);
        return Ok(tasks);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var response = await _taskService.GetTaskById(id);
        return Ok(response);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequestDto createTaskRequestDto)
    {
        var result = await _taskService.CreateTask(createTaskRequestDto);
        
        return CreatedAtAction(
            nameof(GetTaskById),
            new { id = result.Id },
            result);
    }
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskRequestDto dto)
    {
        var result =  await _taskService.UpdateTask(dto, id);
        
        return Ok(result);
    }
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var result = await _taskService.DeleteTask(id);
        return Ok("Deleted task: " + result);
    }
}