using CleanArc.Application.Common.Models;
using CleanArc.Application.TestTables.Commands.CreateTestTable;
using CleanArc.Application.TodoItems.Commands.CreateTodoItem;
using CleanArc.Application.TodoItems.Commands.DeleteTodoItem;
using CleanArc.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArc.Application.TodoItems.Commands.UpdateTodoItemDetail;
using CleanArc.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace CleanArc.Web.Endpoints;

public class TestTables : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateTestTable);
    }
    public Task<int> CreateTestTable(ISender sender, CreateTestTableCommand command)
    {
        return sender.Send(command);
    }

   
}
