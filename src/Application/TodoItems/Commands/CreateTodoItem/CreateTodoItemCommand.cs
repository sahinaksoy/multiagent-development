using MediatR;
using Flywheel.Domain.Entities;
using Flywheel.Application.Common.Interfaces;

namespace Flywheel.Application.TodoItems.Commands.CreateTodoItem;

// 1. REQUEST (Girdi Modeli - Record olmalı)
public record CreateTodoItemCommand : IRequest<int>
{
    public string Title { get; init; } = string.Empty;
}

// 2. HANDLER (İş Mantığı)
public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            Title = request.Title,
            IsDone = false
        };

        _context.TodoItems.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}