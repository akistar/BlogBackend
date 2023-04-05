using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Helpers;

public class TodoContext : DbContext
{
    // protected readonly IConfiguration Configuration;

    // public TodoContext(IConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     var dbConnectionString = Configuration.GetConnectionString("TodoContextDb");
    //     var password = Configuration["Dbpassword"];
    //     var dbConnectionStringWithPassword = dbConnectionString.Replace("password=;", $"password={password};");
    //     optionsBuilder.UseMySql(dbConnectionStringWithPassword, ServerVersion.AutoDetect(dbConnectionStringWithPassword));
    // }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public  DbSet<TodoItem> TodoItems { get; set; }

}