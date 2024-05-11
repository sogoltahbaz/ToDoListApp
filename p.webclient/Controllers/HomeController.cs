using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using web.Models.ViewModels;
using web.Models;
using ItemApiCli.Client;
using ItemApiCli.Api ;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR;

namespace p.webclient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        config = new Configuration()
            {
                BasePath = "http://localhost:5196"
            };
        Api = new ItemsApi(config);
            update_client = new HubConnectionBuilder()
            .WithUrl("http://localhost:5196/update_client")
            .Build();
            update_client.On("updateclient", () =>{});
            update_client.StartAsync();
            update_client.SendAsync("update");
    }

    public IActionResult Index()
    {
        var ItemsModel = GetAllToDoItems();
        return View(ItemsModel);
    }
        HubConnection update_client;
        Configuration config;
        ItemsApi Api;
public RedirectResult Insert(ToDoListModel items)
{
    if(items.todo.ToDoItemsId != null && items.todo.deadline >= DateTime.Now )
    {
        try
        {
            ItemApiCli.Model.ToDoItems item = new ItemApiCli.Model.ToDoItems(items.todo.ToDoItemsId,items.todo.Details,items.todo.deadline);
            Api.ItemsAddItemPost(item);
            update_client.SendAsync("update");
        }
        catch
        {
            return Redirect("/");
        }
    }
    return Redirect("/");
}


internal ToDoListModel GetAllToDoItems()
{
    List<ItemsModel> itemsList = new();
    try
    {
    var items = Api.ItemsGet();
    foreach(var n in items)
    {
        itemsList.Add(new ItemsModel
        {
            ToDoItemsId = n.ToDoItemsId,
            Details = n.Details,
            deadline = n.Deadline
        });
    }
    }
    catch
    {
        return new ToDoListModel
        {
            ItemsList = itemsList
        };
    }
        return new ToDoListModel
        {
            ItemsList = itemsList
        };
}

public RedirectResult Delete(ToDoListModel items)

    {
        if(items.todo.ToDoItemsId != null)
        {
            try
            {
            Api.ItemsDeleteitemIdiDelete(items.todo.ToDoItemsId);
            update_client.SendAsync("update");
            }
            catch
            {
                return Redirect("/");
            }
        }
        return Redirect("/");
    }
}




