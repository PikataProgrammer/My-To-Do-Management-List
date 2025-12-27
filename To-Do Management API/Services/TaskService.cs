using To_Do_Management_API.Data;
using To_Do_Management_API.Dtos.TaskDto;
using To_Do_Management_API.Entities;
using To_Do_Management_API.Interfaces;

namespace To_Do_Management_API.Services;

public class TaskService : ITaskService
{
    private ITaskRepository _taskRepository;
    private IUserRepository _userRepository;

    public TaskService(ITaskRepository taskRepository, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<TaskDto> GetTaskById(int taskId)
    {
        var task = await _taskRepository.GetByIdAsync(taskId);
        if (task == null)
        {
            throw new KeyNotFoundException("Invalid taskId: " + taskId);
        }
        return new TaskDto(task);
    }

    public async Task<List<TaskDto>> GetAllTasks(int? offset, int? limit)
    {
        int safeOffset = offset ?? 0;
        int safeLimit = limit ?? 10;
        
        if (safeLimit > 50)
            safeLimit = 50;

        if (safeOffset < 0)
            safeOffset = 0;
        
       var tasks = await  _taskRepository.GetAllAsync(safeOffset, safeLimit);
       
       return tasks.Select(x => new TaskDto(x)).ToList();
    }
    public async Task<TaskDto> CreateTask(CreateTaskRequestDto dto)
    {
        var allowedStatuses = new[] { "Pending", "InProgress", "Done" };
        var allowedPriorities = new[] { "Low", "Medium", "High" };
        if (!allowedStatuses.Contains(dto.Status))
        {
            throw new ArgumentOutOfRangeException(nameof(dto.Status));
            // return BadRequest($"Invalid Status. Allowed values: {string.Join(", ", allowedStatuses)}");
        }

        if (!allowedPriorities.Contains(dto.Priority))
        {
            throw new ArgumentOutOfRangeException(nameof(dto.Priority));
            // return BadRequest($"Invalid Priority. Allowed values: {string.Join(", ", allowedPriorities)}");
        }

        var entity = new TodoTask(dto);
        
        var user = await _userRepository.GetByIdAsync(dto.UserId);
        ArgumentNullException.ThrowIfNull(user);
        
        user.Tasks.Add(entity);
        await _taskRepository.CreateAsync(entity);
        await _taskRepository.SaveChangesAsync();
        
        return  new TaskDto(entity);
    }

    public async Task<TaskDto> UpdateTask(UpdateTaskRequestDto taskModel, int taskId)
    {
        var todoTask = await _taskRepository.GetByIdAsync(taskId);
        ArgumentNullException.ThrowIfNull(todoTask);
        
       todoTask.Update(taskModel);

       await _taskRepository.SaveChangesAsync();
       
       return new TaskDto(todoTask);
    }

    public async Task<TaskDto> DeleteTask(int taskId)
    {
        var existingTask = await _taskRepository.DeleteAsync(taskId);
        ArgumentNullException.ThrowIfNull(existingTask);
        await _taskRepository.SaveChangesAsync();

        return new TaskDto(existingTask);

    }
}