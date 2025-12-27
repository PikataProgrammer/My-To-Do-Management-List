using To_Do_Management_API.Dtos.TaskDto;

namespace To_Do_Management_API.Interfaces;

public interface ITaskService
{
    Task<TaskDto> GetTaskById(int taskId);
    Task<List<TaskDto>> GetAllTasks(int? offset, int? limit);
    Task<TaskDto> CreateTask(CreateTaskRequestDto taskModel);
    Task<TaskDto> UpdateTask(UpdateTaskRequestDto taskModel, int taskId);
    Task<TaskDto> DeleteTask(int taskId);
}