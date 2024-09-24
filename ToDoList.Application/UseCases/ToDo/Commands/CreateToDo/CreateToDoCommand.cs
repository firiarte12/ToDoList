using MediatR;
using ToDoList.Application.Dtos.Results;
using ToDoList.Application.Interfaces.Infrastructure;
using ToDoList.Application.UseCases.Handlers;
using ToDoList.Domain.Entity;

namespace Application.UseCases.Transactions.Commands.CreateTransaction;

public class CreateToDoCommand : CreateToDoCommandModel, IRequest<Result<CreateToDoCommandDto>>
{
    public class CreateTransactionCommandHandler(
        IRepository<ToDo> toDoRepository) : UseCaseHandler, IRequestHandler<CreateToDoCommand, Result<CreateToDoCommandDto>>
    {
        public async Task<Result<CreateToDoCommandDto>> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = new ToDo
            {
                title = request.title,
                description = request.description,
                status = "P", //PENDING-COMPLETED
            };

            await toDoRepository.AddAsync(toDo);

            var resultData = new CreateToDoCommandDto { Success = true };

            return Succeded(resultData);
        }
    }
}
