using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<TodoItemDto>> GetAllTodosAsync();
    Task<TodoItemDto?> GetTodoByIdAsync(int id);
    Task<TodoItemDto> CreateTodoAsync(TodoItemDto todoDto);
    Task UpdateTodoAsync(int id, TodoItemDto todoDto);
    Task DeleteTodoAsync(int id);
    Task CompleteTodoAsync(int id);
}
