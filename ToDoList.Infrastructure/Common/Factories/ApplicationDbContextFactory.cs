using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Infrastructure.Common.Factories;

public class ApplicationDbContextFactory : IDbContextFactory
{
    private readonly DbContextOptions<ApplicationDbContext> options;

    public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options)
    {
        this.options = options;
    }

    public DbContext Create()
    {
        return new ApplicationDbContext(this.options);
    }
}
