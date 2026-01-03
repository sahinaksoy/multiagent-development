using Flywheel.Application.TodoItems.Commands.CreateTodoItem;
using Flywheel.Application.TodoItems.Queries.GetTodoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flywheel.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoItemDto>>> Get()
    {
        // Mediator, GetTodoItemsQueryHandler'ı bulup çalıştıracak
        return await _mediator.Send(new GetTodoItemsQuery());
    }
}