using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<TodoItemDto>> GetAllTodosAsync()
    {
        var todos = await _todoRepository.GetAllAsync();
        return todos.Select(MapToDto);
    }

    public async Task<TodoItemDto?> GetTodoByIdAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        return todo != null ? MapToDto(todo) : null;
    }

    public async Task<TodoItemDto> CreateTodoAsync(TodoItemDto todoDto)
    {
        var todo = MapToEntity(todoDto);
        todo.CreatedAt = DateTime.UtcNow;
        var created = await _todoRepository.CreateAsync(todo);
        return MapToDto(created);
    }

    public async Task UpdateTodoAsync(int id, TodoItemDto todoDto)
    {
        var existingTodo = await _todoRepository.GetByIdAsync(id) 
            ?? throw new KeyNotFoundException($"Todo with ID {id} not found");
        
        existingTodo.Title = todoDto.Title;
        existingTodo.Description = todoDto.Description;
        existingTodo.Priority = todoDto.Priority;
        
        await _todoRepository.UpdateAsync(existingTodo);
    }

    public async Task DeleteTodoAsync(int id)
    {
        await _todoRepository.DeleteAsync(id);
    }

    public async Task CompleteTodoAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id) 
            ?? throw new KeyNotFoundException($"Todo with ID {id} not found");
        
        todo.IsCompleted = true;
        todo.CompletedAt = DateTime.UtcNow;
        
        await _todoRepository.UpdateAsync(todo);
    }

    private static TodoItemDto MapToDto(TodoItem todo)
    {
        return new TodoItemDto
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            IsCompleted = todo.IsCompleted,
            CreatedAt = todo.CreatedAt,
            CompletedAt = todo.CompletedAt,
            Priority = todo.Priority
        };
    }

    private static TodoItem MapToEntity(TodoItemDto dto)
    {
        return new TodoItem
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted,
            CreatedAt = dto.CreatedAt,
            CompletedAt = dto.CompletedAt,
            Priority = dto.Priority
        };
    }
}
