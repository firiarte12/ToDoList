using Application.UseCases.Transactions.Commands.CreateTransaction;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<CreateToDoCommandModel, CreateToDoCommand>();
    }
}
