using Xunit;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MockQueryable.Moq;

namespace TodoApi.Unit.Tests{
public class TestTodoItemsController
{

    private readonly DbContextOptions<TodoContext> _dbOptions;


    public TestTodoItemsController()
    {
        _dbOptions = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(databaseName: "TodoList")
            .Options;

        using var dbcontext = new TodoContext(_dbOptions);
        dbcontext.AddRange(GetTestTodoItems());
        dbcontext.SaveChanges();

    }


    [Fact]
    public async Task Return_List_TODOITEMS()
    {

        var fakeTodoItems = GetTestTodoItems();

        var controller = new TodoItemsController(new TodoContext(_dbOptions));
        var result = await controller.GetTodoItems();

        result.Value.ToList().ForEach(item => System.Console.WriteLine(item.Name));
        Assert.Equal(3, result.Value.Count());

    
    }


    private IQueryable<TodoItem> GetTestTodoItems()
    {
        var testTodoItems = new List<TodoItem>();
        testTodoItems.Add(new TodoItem { Id = "1", Name = "Item1", IsComplete = false, Created = DateTime.Now, Content = "Content1" });
        testTodoItems.Add(new TodoItem { Id = "2", Name = "Item2", IsComplete = false, Created = DateTime.Now, Content = "Content2" });
        testTodoItems.Add(new TodoItem { Id = "3", Name = "Item3", IsComplete = false, Created = DateTime.Now, Content = "Content3" });
        return testTodoItems.AsQueryable();
    }

}



}