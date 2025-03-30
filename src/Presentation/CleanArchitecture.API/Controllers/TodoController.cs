using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    [Authorize(Policy = Permissions.TodoView)]
    public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll()
    {
        var todos = await _todoService.GetAllTodosAsync();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = Permissions.TodoView)]
    public async Task<ActionResult<TodoItemDto>> GetById(int id)
    {
        var todo = await _todoService.GetTodoByIdAsync(id);
        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    [HttpPost]
    [Authorize(Policy = Permissions.TodoCreate)]
    public async Task<ActionResult<TodoItemDto>> Create(TodoItemDto todoDto)
    {
        var created = await _todoService.CreateTodoAsync(todoDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = Permissions.TodoEdit)]
    public async Task<IActionResult> Update(int id, TodoItemDto todoDto)
    {
        try
        {
            await _todoService.UpdateTodoAsync(id, todoDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = Permissions.TodoDelete)]
    public async Task<IActionResult> Delete(int id)
    {
        await _todoService.DeleteTodoAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}/complete")]
    [Authorize(Policy = Permissions.TodoEdit)]
    public async Task<IActionResult> Complete(int id)
    {
        try
        {
            await _todoService.CompleteTodoAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
