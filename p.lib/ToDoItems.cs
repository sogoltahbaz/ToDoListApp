namespace p.lib;
public class ToDoItems
{
    public ToDoItems(string toDoItemsId, string details, DateTime deadline)
    {
        ToDoItemsId = toDoItemsId;
        Details = details;
        this.deadline = deadline;
    }

    public string ToDoItemsId{get;private set;}
    public string Details{get; set;}
    public DateTime deadline{get;private set;}
    
    public override string ToString()
    {
        return $"{this.ToDoItemsId} , {this.Details} , {this.deadline} ";
    }
}