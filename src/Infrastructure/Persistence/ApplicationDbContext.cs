using Microsoft.EntityFrameworkCore;
using Flywheel.Domain.Entities;
using Flywheel.Application.Common.Interfaces;

namespace Flywheel.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
}