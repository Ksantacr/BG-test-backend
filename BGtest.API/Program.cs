using System.Reflection;
using BGTest.Application;
using BGTest.Infrastructure;
using BGTest.Infrastructure.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddInfrastructure()
    .AddAplication()
    .AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
         options.SwaggerEndpoint("/openapi/v1.json", "BGtest.API");
    });
    
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors("all");

app.Run();