using ToDoList.Shared.Core;
using ToDoList.Application;
using ToDoList.Infrastructure;
using ToDoList.Api.Exceptions;

var builder = WebApplication.CreateBuilder(args);

EngineContext.Create();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region exceptions services
builder.Services.AddExceptionHandler<ForbiddenExceptionHandler>();
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<InternalServerExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
#endregion

#region layers dependency injections
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
#endregion


builder.Services.AddSwaggerGen();

var app = builder.Build();

EngineContext.Current.Configure(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
