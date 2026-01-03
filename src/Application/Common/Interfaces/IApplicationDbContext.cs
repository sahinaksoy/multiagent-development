using Microsoft.EntityFrameworkCore;
using Flywheel.Domain.Entities;

namespace Flywheel.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}