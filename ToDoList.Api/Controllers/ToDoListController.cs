using Application.UseCases.Transactions.Commands.CreateTransaction;
using Microsoft.AspNetCore.Mvc;
namespace ToDoList.Api.Controllers;

public class ToDoListController : BaseController
{
    [HttpPost]
    [Route("Create")]
    [Produces(typeof(CreateToDoCommandDto))]
    [ActionName(nameof(CreateTransaction))]
    public async Task<IActionResult> CreateTransaction(CreateToDoCommandModel model)
    {
        var command = this.Mapper.Map<CreateToDoCommand>(model);
        var result = await this.Mediator.Send(command);
        return this.FromResult(result);
    }
        
}
