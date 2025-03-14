using CleanArc.Domain.Entities;

namespace CleanArc.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Test> Tests { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
