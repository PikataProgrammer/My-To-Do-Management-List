using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_Management_API.Data;
using To_Do_Management_API.Dtos.TaskDto;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;
using To_Do_Management_API.Mappers;

namespace To_Do_Management_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _taskRepo;
    private readonly IUserRepository _userRepo;
    public TasksController(ITaskRepository taskRepo, IUserRepository userRepo)
    {
        _taskRepo = taskRepo;
        _userRepo = userRepo;
    }

    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetTasksByUserId(int userId)
    {
        var tasks = await _taskRepo.GetAllAsync();
        var userTasks = tasks.Where(x => x.UserId == userId).ToList();
        return Ok(userTasks.Select(x => x.ToTaskDto()));
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _taskRepo.GetAllAsync();
        var taskDto = tasks.Select(x => x.ToTaskDto());
        return Ok(taskDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskRepo.GetByIdAsync(id);
        
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task.ToTaskDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequestDto dto)
    {
        var allowedStatuses = new[] { "Pending", "InProgress", "Done" };
        var allowedPriorities = new[] { "Low", "Medium", "High" };
        if (!allowedStatuses.Contains(dto.Status))
        {
            return BadRequest($"Invalid Status. Allowed values: {string.Join(", ", allowedStatuses)}");
        }

        if (!allowedPriorities.Contains(dto.Priority))
        {
            return BadRequest($"Invalid Priority. Allowed values: {string.Join(", ", allowedPriorities)}");
        }
        
        var taskModel = dto.ToTaskFromCreateDto();   
        var user = await _userRepo.GetByIdAsync(dto.UserId);
        if (user == null)
        {
            return BadRequest($"User {dto.UserId} does not exist.");
        }
        
        user.Tasks.Add(taskModel);
        await _taskRepo.CreateAsync(taskModel);
        
        return CreatedAtAction(
            nameof(GetTaskById),
            new { id = taskModel.Id },
            taskModel.ToTaskDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskRequestDto dto)
    {
        var updatedTask = await _taskRepo.UpdateAsync(id, dto.ToTaskFromUpdateDto());
        
        if (updatedTask == null)
        {
            return NotFound();
        }
        
        return Ok(updatedTask.ToTaskDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var existingTask = await _taskRepo.DeleteAsync(id);

        if (existingTask == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}