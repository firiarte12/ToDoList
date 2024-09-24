using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Interfaces.Infrastructure;

public interface IStoredProcedure<T>
    where T : notnull
{
    Task<IEnumerable<T>> ExecuteStoredProcedureQuery(string query);
    Task<T> ExecuteStoredProcedureQueryFirst(string query);
    Task<int> ExecuteStoredProcedureCommand(string query);
}
