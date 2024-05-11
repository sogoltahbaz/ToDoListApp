using ItemApiCli.Api; 
using ItemApiCli.Model;
using ItemApiCli.Client; 
using System;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR;
public class program
{
    public static void Main()
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5196"}; 
        ItemsApi apiInstance = new ItemsApi(config); 
        HubConnection update_client = new HubConnectionBuilder()
        .WithUrl("http://localhost:5196/update_client")
        .Build();
        update_client.On("updateclient", () =>{});
        update_client.StartAsync();
        var input = menu();
        switch(input) 
        {
            case "1":
                Add();
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("your task succesfully added");
                Console.WriteLine("\n");
                update_client.SendAsync("update");
                Main();
                break;
            case "2":
                Delete();
                Console.WriteLine("\n");
                update_client.SendAsync("update");
                Main();
                break;
            case "3":
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach(var s in apiInstance.ItemsGet())
                        Console.WriteLine(s);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("unable to get tasks");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("for return to main menu enter anything");
                Console.ReadKey();
                Console.WriteLine("\n");
                Main();
                break;
        }
    }

    public static void Delete()
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5196"}; 
        ItemsApi apiInstance = new ItemsApi(config);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("please enter your task name to delete");
        var Name = Console.ReadLine();
        try
        {
            apiInstance.ItemsDeleteitemIdiDelete(Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("your task succesfully deleted");
        }
        catch 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("your task not found");
        }
    }

    public static void Add()
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5196"}; 
        ItemsApi apiInstance = new ItemsApi(config);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("please enter your task name");
        var Name = Console.ReadLine();
        // System.Console.WriteLine("\n");
        Console.WriteLine("please enter your task details");
        var Details = Console.ReadLine();
        // Console.WriteLine("year");
        // Console.WriteLine("year");
        int year = 0;
        var input1 = "1";
        // var input1 = Console.ReadLine();
        bool situ = true;
        while (situ)
        {
            if (!int.TryParse(input1, out year) || (year < 2022) || (year > 2041))
            {
                Console.WriteLine("please enter number of year");
                input1 = Console.ReadLine();
            }
            else
            {
                situ = false;
            }
        }
        int month = 0;
        var input2 = "0";
        situ = true;
        while (situ)
        {
            if (!int.TryParse(input2, out month) || (month < 1) || (month > 12))
            {
                Console.WriteLine("please enter number of month");
                input2 = Console.ReadLine();
            }
            else
            {
                situ = false;
            }
        }
        int day = 0;
        var input3 = "0";
        situ = true;
        DateTime date = DateTime.Now;
        while (situ)
        {
            if (!int.TryParse(input3, out day) || (day < 1) || (day > 30))
            {
                Console.WriteLine("please enter number of day");
                input3 = Console.ReadLine();
            }
            else
                situ = false;
        }
        if (month == 2 && day > 28)
            day = 28;
        date = DateTime.Parse($"{month}/{day}/{year}");


        ToDoItems item = new ToDoItems(Name , Details , date);
        try
        {
            apiInstance.ItemsAddItemPost(item);
        }
        catch(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("failed to add task");
        }
    }

    public static string menu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("To Do List");
        System.Console.WriteLine("1- Add");
        System.Console.WriteLine("2- Delete");
        System.Console.WriteLine("3- Show Tasks");
        string input = "0";
        for (int i = 0; i < 100; i++)
        {
            input = Console.ReadLine();
            if (input == "1" || input == "2" || input == "3")
                break;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("please choose from 1 and 2 and 3");
        }
        return input;
    }
}


