using web.Models;
using System;

namespace web.Models.ViewModels;

public class ToDoListModel
{
    public List<ItemsModel> ItemsList{get; set;}
    public ItemsModel todo {get;set;}
}