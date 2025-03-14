using CleanArc.Application.Common.Interfaces;
using CleanArc.Domain.Entities;

namespace CleanArc.Application.TestTables.Commands.CreateTestTable;

public record CreateTestTableCommand : IRequest<int>
{
    public string? Name { get; set; }
}

public class CreateTestTableCommandValidator : AbstractValidator<CreateTestTableCommand>
{
    public CreateTestTableCommandValidator()
    {
    }
}

public class CreateTestTableCommandHandler : IRequestHandler<CreateTestTableCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTestTableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTestTableCommand request, CancellationToken cancellationToken)
    {
        var entitys = new TestTable
        {
            Name = request.Name
        };
        _context.TestTables.Add(entitys);
        await _context.SaveChangesAsync(cancellationToken);

        return entitys.Id;
    }
}
