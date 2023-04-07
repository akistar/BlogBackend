using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configuration = builder.Configuration;

var dbConnectionString = configuration.GetConnectionString("TodoContextDb");

var envPassword = Environment.GetEnvironmentVariable("Dbpassword");

var configPassword = configuration["Dbpassword"];
System.Console.WriteLine("env "+ envPassword );
System.Console.WriteLine("config "+ configPassword );
var password = envPassword ?? configPassword;
var dbConnectionStringWithPassword = dbConnectionString.Replace("password=;", $"password={password};");

builder.Services.AddDbContext<TodoContext>(opt => opt.UseMySql(
    dbConnectionStringWithPassword,
    ServerVersion.AutoDetect(dbConnectionStringWithPassword)
));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();