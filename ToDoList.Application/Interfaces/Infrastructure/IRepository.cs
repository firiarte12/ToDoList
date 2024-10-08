﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entity;

namespace ToDoList.Application.Interfaces.Infrastructure;

public interface IRepository<T>
    where T : BaseEntity
{
    IQueryable<T> GetAll();

    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(Guid id);

    Task<T> GetByIdAsync(string id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task RemoveAsync(T entity);

    Task<IEnumerable<T>> ExecuteStoredProcedure(string query);
}
