using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces.Infrastructure;
using ToDoList.Infrastructure.Common.Factories;
using ToDoList.Infrastructure.DbContexts;
using ToDoList.Infrastructure.Repositories;


namespace ToDoList.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLConnection");

        // DB context
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IDbContextFactory, ApplicationDbContextFactory>(s =>
        {
            var connectionString = configuration.GetSection("ConnectionStrings:SQLConnection").Value;
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(
                connectionString,
                b =>
                {
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                })
                .Options;
            return new ApplicationDbContextFactory(options);
        });

        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient(typeof(IStoredProcedure<>), typeof(StoredProcedure<>));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        //services.AddAuthorizationBuilder();

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
