using Microsoft.EntityFrameworkCore;
using p.lib;

public class ItemsContext : DbContext
{
    public ItemsContext(DbContextOptions<ItemsContext> options)
        : base(options)
    {
        
    }
    public DbSet<ToDoItems> todoitem {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=todoitem.db");

    }
}