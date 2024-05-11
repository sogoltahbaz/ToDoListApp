using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using p.lib;
using ItemApiCli.Client;
using ItemApiCli.Api ; 
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR;

namespace p.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection update_client;
        public MainWindow()
        {
            InitializeComponent();
            config = new Configuration()
            {
                BasePath = "http://localhost:5196"
            };
            Api = new ItemsApi(config);
            update_client = new HubConnectionBuilder()
            .WithUrl("http://localhost:5196/update_client")
            .Build();
            update_client.On("updateclient", () =>{var tasks = showitems();
            dataGrid.ItemsSource= tasks;});
            update_client.StartAsync();
            update_client.SendAsync("update");
        }

        Configuration config;
        ItemsApi Api;

        private List<ItemApiCli.Model.ToDoItems> showitems()
        {
            var items = Api.ItemsGet();
            return items;
        }

        public void add(object sender , RoutedEventArgs e)
        {
            if(CheckBoxes())
            {
            ItemApiCli.Model.ToDoItems item = new ItemApiCli.Model.ToDoItems(Name.Text,Details.Text,Date.SelectedDate.GetValueOrDefault());
            Api.ItemsAddItemPost(item);
            update_client.SendAsync("update");
            MessageBox.Show("your task succesfully added");
            Reset();
            }
            else
            MessageBox.Show("please fill all blank to add");
        }

        private bool CheckBoxes()
        {
            if(Name.Text == null || Details.Text == null || Date.SelectedDate == null )
                return false;
            return true;
        }

        public void Reset()
        {
            Name.Text = string.Empty;
            Details.Text = string.Empty;
            Date.SelectedDate = null;
        }

        public void delete(object sender , RoutedEventArgs e)
        {
            if(Name.Text != null)
            {
            try
            {
            Api.ItemsDeleteitemIdiDelete(Name.Text);
            update_client.SendAsync("update");
            MessageBox.Show("your task succesfully deleted");
            }
            catch
            {
                MessageBox.Show("your task Id not found");
            }
            Reset();
            }
            else
            MessageBox.Show("please choose a Id to delete");
        }
    }
}
