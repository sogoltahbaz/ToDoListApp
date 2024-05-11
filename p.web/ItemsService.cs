using Microsoft.EntityFrameworkCore;
using p.lib;

public class ItemsService
{
    private readonly ItemsContext _context;
    public ItemsService(ItemsContext context)
    {
        _context = context;
    }

    public IEnumerable<ToDoItems> GetAll() => _context.todoitem.AsNoTracking().ToList();

    public ToDoItems GetItemById(string id) => _context.todoitem
        .AsNoTracking()
        .SingleOrDefault(p => p.ToDoItemsId == id);

    public ToDoItems AddItem(ToDoItems newItem)
    {
        _context.todoitem.Add(newItem);
        _context.SaveChanges();
        return newItem;
    }

    public void DeleteItemById(string id)
    {
        var Item2delete = _context.todoitem.Find(id);
        if (Item2delete is not null)
        {
            _context.todoitem.Remove(Item2delete);
            _context.SaveChanges();
        }
    }
}