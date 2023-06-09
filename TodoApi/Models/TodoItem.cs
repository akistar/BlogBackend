namespace TodoApi.Models;

public class TodoItem
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public DateTime Created {get; set;}
    public string? Content { get; set; }
}