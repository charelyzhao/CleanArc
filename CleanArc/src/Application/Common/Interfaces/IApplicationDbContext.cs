using CleanArc.Domain.Entities;

namespace CleanArc.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<TestTable> TestTables { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
