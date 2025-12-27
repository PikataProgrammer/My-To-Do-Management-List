using To_Do_Management_API.Dtos.TaskDto;
using To_Do_Management_API.Entities;

namespace To_Do_Management_API.Mappers;

public static class TaskMapper
{
    // public static TaskDto ToTaskDto(this TodoTask task)
    // {
    //     return new TaskDto
    //     {
    //         Id = task.Id,
    //         Title = task.Title,
    //         Description = task.Description,
    //         Status = task.Status,
    //         Priority = task.Priority,
    //         CreatedAt = task.CreatedAt,
    //         DueDate = task.DueDate,
    //         UserId = task.UserId
    //     };
    // }
    //
    // public static TodoTask ToTaskFromCreateDto(this CreateTaskRequestDto dto)
    // {
    //     return new TodoTask
    //     {
    //         Title = dto.Title,
    //         Description = dto.Description,
    //         Status = dto.Status,
    //         Priority = dto.Priority,
    //         CreatedAt = DateTime.Now,
    //         DueDate =  dto.DueDate,
    //         UserId = dto.UserId
    //     };
    // }
    //
    // public static TodoTask ToTaskFromUpdateDto(this UpdateTaskRequestDto dto)
    // {
    //     return new TodoTask
    //     {
    //         Title = dto.Title,
    //         Description = dto.Description,
    //         Status = dto.Status,
    //         Priority = dto.Priority,
    //         DueDate = dto.DueDate,
    //     };
    // }
}