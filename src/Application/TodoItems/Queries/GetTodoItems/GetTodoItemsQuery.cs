using MediatR;
using Microsoft.EntityFrameworkCore;
using Flywheel.Application.Common.Interfaces;
using Flywheel.Domain.Entities;

namespace Flywheel.Application.TodoItems.Queries.GetTodoItems;

// 1. DTO (Veriyi dışarı nasıl vereceğiz?)
public class TodoItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}

// 2. QUERY (İstek)
public record GetTodoItemsQuery : IRequest<List<TodoItemDto>>;

// 3. HANDLER (İş Mantığı)
public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, List<TodoItemDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTodoItemsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItemDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoItems
            .Select(x => new TodoItemDto
            {
                Id = x.Id,
                Title = x.Title,
                IsDone = x.IsDone
            })
            .ToListAsync(cancellationToken);
    }
}